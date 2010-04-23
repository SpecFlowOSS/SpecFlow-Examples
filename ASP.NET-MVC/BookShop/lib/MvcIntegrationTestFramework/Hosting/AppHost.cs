using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using MvcIntegrationTestFramework.Browsing;
using MvcIntegrationTestFramework.Interception;

namespace MvcIntegrationTestFramework.Hosting
{
    /// <summary>
    /// Hosts an ASP.NET application within an ASP.NET-enabled .NET appdomain
    /// and provides methods for executing test code within that appdomain
    /// </summary>
    public class AppHost
    {
        private readonly AppDomainProxy appDomainProxy; // The gateway to the ASP.NET-enabled .NET appdomain

        public AppHost(string appPhysicalDirectory) : this(appPhysicalDirectory, "/")
        {
        }

        public AppHost(string appPhysicalDirectory, string virtualDirectory)
        {
            try {
                appDomainProxy = (AppDomainProxy) ApplicationHost.CreateApplicationHost(typeof (AppDomainProxy), virtualDirectory, appPhysicalDirectory);
            } catch(FileNotFoundException ex) {
                if((ex.Message != null) && ex.Message.Contains("MvcIntegrationTestFramework"))
                    throw new InvalidOperationException("Could not load MvcIntegrationTestFramework.dll within a bin directory under " + appPhysicalDirectory + ". Is this the path to your ASP.NET MVC application, and have you set up a post-build event to copy your test assemblies and their dependencies to this folder? See the demo project for an example.");
                throw;
            }

            appDomainProxy.RunCodeInAppDomain(() => {
                InitializeApplication();
                AttachTestControllerDescriptorsForAllControllers();
                LastRequestData.Reset();
            });
        }

        public void SimulateBrowsingSession(Action<BrowsingSession> testScript)
        {
            var serializableDelegate = new SerializableDelegate<Action<BrowsingSession>>(testScript);
            appDomainProxy.RunBrowsingSessionInAppDomain(serializableDelegate);
        }

        private static void CopyFields<T>(T from, T to) where T : class
        {
            if ((from != null) && (to != null))
            {
                foreach (FieldInfo info in from.GetType().GetFields())
                {
                    info.SetValue(to, info.GetValue(from));
                }
            }
        }
        
        public TResult SimulateBrowsingSession<TResult>(Func<BrowsingSession, TResult> testScript)
        {
            var serializableDelegate = new SerializableDelegate<Func<BrowsingSession, TResult>>(testScript);
            FuncExecutionResult<TResult> result = appDomainProxy.RunBrowsingSessionInAppDomain2(serializableDelegate);
            CopyFields<object>(result.DelegateCalled.Delegate.Target, testScript.Target);
            return result.DelegateCallResult;
            //return appDomainProxy.RunBrowsingSessionInAppDomain(serializableDelegate);
        } 
        
        public void ContinueBrowsingSession(Action<BrowsingSession> testScript)
        {
            var serializableDelegate = new SerializableDelegate<Action<BrowsingSession>>(testScript);
            appDomainProxy.RunBrowsingSessionInAppDomain(serializableDelegate);
        }

        #region Initializing app & interceptors
        private static void InitializeApplication()
        {
            var appInstance = GetApplicationInstance();
            appInstance.PostRequestHandlerExecute += delegate {
                // Collect references to context objects that would otherwise be lost
                // when the request is completed
                if(LastRequestData.HttpSessionState == null)
                    LastRequestData.HttpSessionState = HttpContext.Current.Session;
                if (LastRequestData.Response == null)
                    LastRequestData.Response = HttpContext.Current.Response;
            };
            RefreshEventsList(appInstance);

            RecycleApplicationInstance(appInstance);
        }

        private static void AttachTestControllerDescriptorsForAllControllers()
        {
            var allControllerTypes = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where typeof (IController).IsAssignableFrom(type)
                                     select type;
            foreach (var controllerType in allControllerTypes)
                InterceptionFilter.AssociateWithControllerType(controllerType);
        }
        #endregion

        #region Reflection hacks
        private static readonly MethodInfo getApplicationInstanceMethod;
        private static readonly MethodInfo recycleApplicationInstanceMethod;

        static AppHost()
        {
            // Get references to some MethodInfos we'll need to use later to bypass nonpublic access restrictions
            var httpApplicationFactory = typeof(HttpContext).Assembly.GetType("System.Web.HttpApplicationFactory", true);
            getApplicationInstanceMethod = httpApplicationFactory.GetMethod("GetApplicationInstance", BindingFlags.Static | BindingFlags.NonPublic);
            recycleApplicationInstanceMethod = httpApplicationFactory.GetMethod("RecycleApplicationInstance", BindingFlags.Static | BindingFlags.NonPublic);
        }

        private static HttpApplication GetApplicationInstance()
        {
            var writer = new StringWriter();
            var workerRequest = new SimpleWorkerRequest("", "", writer);
            var httpContext = new HttpContext(workerRequest);
            return (HttpApplication)getApplicationInstanceMethod.Invoke(null, new object[] { httpContext });
        }

        private static void RecycleApplicationInstance(HttpApplication appInstance)
        {
            recycleApplicationInstanceMethod.Invoke(null, new object[] { appInstance });
        }

        private static void RefreshEventsList(HttpApplication appInstance)
        {
            object stepManager = typeof (HttpApplication).GetField("_stepManager", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(appInstance);
            object resumeStepsWaitCallback = typeof(HttpApplication).GetField("_resumeStepsWaitCallback", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(appInstance);
            var buildStepsMethod = stepManager.GetType().GetMethod("BuildSteps", BindingFlags.NonPublic | BindingFlags.Instance);
            buildStepsMethod.Invoke(stepManager, new[] { resumeStepsWaitCallback });
        }

        #endregion
    }
}