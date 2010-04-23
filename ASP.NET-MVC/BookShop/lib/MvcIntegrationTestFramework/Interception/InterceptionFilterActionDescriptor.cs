using System.Reflection;
using System.Web.Mvc;

namespace MvcIntegrationTestFramework.Interception
{
    /// <summary>
    /// A special ASP.NET MVC action descriptor used to attach InterceptionFilter to all loaded controllers
    /// </summary>
    internal class InterceptionFilterActionDescriptor : ReflectedActionDescriptor
    {
        public InterceptionFilterActionDescriptor(MethodInfo methodInfo, string actionName, ControllerDescriptor controllerDescriptor)
            : base(methodInfo, actionName, controllerDescriptor)
        {
        }

        public override FilterInfo GetFilters()
        {
            var usualFilters = base.GetFilters();
            var interceptionFilter = new InterceptionFilter();
            usualFilters.ActionFilters.Insert(0, interceptionFilter);
            usualFilters.ResultFilters.Insert(0, interceptionFilter);
            return usualFilters;
        }
    }
}