using System;
using MvcIntegrationTestFramework.Browsing;

namespace MvcIntegrationTestFramework.Hosting
{
    /// <summary>
    /// Simply provides a remoting gateway to execute code within the ASP.NET-hosting appdomain
    /// </summary>
    internal class AppDomainProxy : MarshalByRefObject
    {
        public void RunCodeInAppDomain(Action codeToRun)
        {
            codeToRun();
        }

        public FuncExecutionResult<TResult> RunBrowsingSessionInAppDomain2<TResult>(SerializableDelegate<Func<BrowsingSession, TResult>> script)
        {
//            var browsingSession = new BrowsingSession();
            var browsingSession = BrowsingSession.Instance;
            var local = script.Delegate(browsingSession);
            FuncExecutionResult<TResult> result = new FuncExecutionResult<TResult>();
            result.DelegateCalled = script;
            result.DelegateCallResult = local;
            return result;
        } 
        
        public void RunBrowsingSessionInAppDomain(SerializableDelegate<Action<BrowsingSession>> script)
        {
//            var browsingSession = new BrowsingSession();
            var browsingSession = BrowsingSession.Instance;
            script.Delegate(browsingSession);
        } 
        
        public void ContinueBrowsingSessionInAppDomain(SerializableDelegate<Action<BrowsingSession>> script)
        {
            var browsingSession = BrowsingSession.Instance;
            script.Delegate(browsingSession);
        }

        public override object InitializeLifetimeService()
        {
            return null; // Tells .NET not to expire this remoting object
        }
    }
}