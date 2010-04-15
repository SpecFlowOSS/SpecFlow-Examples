using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Moq;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Support
{
    [Binding]
    public class HttpContextStub
    {
        class StubSession : HttpSessionStateBase
        {
            readonly Dictionary<string, object> state = new Dictionary<string, object>();
            public override object this[string name]
            {
                get
                {
                    if (!state.ContainsKey(name))
                        return null;
                    return state[name];
                }
                set
                {
                    state[name] = value;
                }
            }
        }

        private static StubSession sessionStub = null;

        [BeforeScenario]
        public void CleanReferenceBooks()
        {
            sessionStub = null;
        }

        public static HttpContextBase Get()
        {
            var httpContextStub = new Mock<HttpContextBase>();
            if (sessionStub == null)
            {
                sessionStub = new StubSession();
            }
            httpContextStub.SetupGet(m => m.Session).Returns(sessionStub);
            return httpContextStub.Object;
        }

        public static void SetupController(Controller controller)
        {
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = Get();
        }
    }
}
