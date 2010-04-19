using System;
using MvcIntegrationTestFramework.Browsing;

namespace MvcIntegrationTestFramework.Hosting
{
    [Serializable]
    internal class FuncExecutionResult<T>
    {
        public SerializableDelegate<Func<BrowsingSession, T>> DelegateCalled { get; set; }
        public T DelegateCallResult { get; set; }
    }
}