using System;
using System.Web.Mvc;

namespace MvcIntegrationTestFramework.Interception
{
    /// <summary>
    /// A special ASP.NET MVC controller descriptor used to attach InterceptionFilter to all loaded controllers
    /// </summary>
    internal class InterceptionFilterControllerDescriptor : ReflectedControllerDescriptor
    {
        public InterceptionFilterControllerDescriptor(Type controllerType) : base(controllerType)
        {
        }

        public override ActionDescriptor FindAction(ControllerContext controllerContext, string actionName)
        {
            var normalActionDescriptor = (ReflectedActionDescriptor)base.FindAction(controllerContext, actionName);
            return new InterceptionFilterActionDescriptor(normalActionDescriptor.MethodInfo, actionName, this);
        }
    }
}