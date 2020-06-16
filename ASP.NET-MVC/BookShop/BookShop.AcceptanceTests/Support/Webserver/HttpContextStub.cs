using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Support.Webserver
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
            private readonly Dictionary<string, byte[]> _state = new Dictionary<string, byte[]>();

            
            public void Clear()
            {
                _state.Clear();
            }

            public Task CommitAsync(CancellationToken cancellationToken = new CancellationToken())
            {
                return Task.CompletedTask;
            }

            public Task LoadAsync(CancellationToken cancellationToken = new CancellationToken())
            {
                return Task.CompletedTask;
            }

            public void Remove(string key)
            {
                _state.Remove(key);
            }

            public void Set(string key, byte[] value)
            {
                if (_state.ContainsKey(key))
                {
                    _state[key] = value;
                    return;
                }
                
                _state.Add(key, value);
            }

            public bool TryGetValue(string key, out byte[] value)
            {
                return _state.TryGetValue(key, out value);
            }

            public string Id { get; } = Guid.NewGuid().ToString();
            public bool IsAvailable { get; } = true;
            public IEnumerable<string> Keys => _state.Keys;
        }
    }
}
