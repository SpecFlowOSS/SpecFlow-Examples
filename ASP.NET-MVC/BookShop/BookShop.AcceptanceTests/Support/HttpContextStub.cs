using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Moq;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Support
{
    [Binding]
    public class HttpContextStub
    {
        private static StubSession SessionStub;

        [BeforeScenario]
        public void CleanReferenceBooks()
        {
            SessionStub = null;
        }

        public static HttpContext Get()
        {
            var httpContextStub = new Mock<HttpContext>();
            if (SessionStub == null)
            {
                SessionStub = new StubSession();
            }

            httpContextStub.SetupGet(m => m.Session).Returns(SessionStub);
            return httpContextStub.Object;
        }

        public static void SetupController(Controller controller)
        {
            controller.ControllerContext = new ControllerContext { HttpContext = Get() };
        }

        private class StubSession : ISession
        {
            private readonly Dictionary<string, object> _state = new Dictionary<string, object>();

            public object this[string name]
            {
                get => !_state.ContainsKey(name) ? null : _state[name];
                set => _state[name] = value;
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public Task CommitAsync(CancellationToken cancellationToken = new CancellationToken())
            {
                throw new NotImplementedException();
            }

            public Task LoadAsync(CancellationToken cancellationToken = new CancellationToken())
            {
                throw new NotImplementedException();
            }

            public void Remove(string key)
            {
                throw new NotImplementedException();
            }

            public void Set(string key, byte[] value)
            {
                throw new NotImplementedException();
            }

            public bool TryGetValue(string key, out byte[] value)
            {
                throw new NotImplementedException();
            }

            public string Id { get; }
            public bool IsAvailable { get; }
            public IEnumerable<string> Keys { get; }
        }
    }
}
