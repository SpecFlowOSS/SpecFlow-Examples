using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace MvcIntegrationTestFramework.Interception
{
    /// <summary>
    /// A place to store information about each request as we capture it
    /// Static because HttpRuntime.ProcessRequest() exposes no convenient hooks for intercepting the
    /// request processing pipeline, so we're statically attaching an interceptor to all loaded controllers
    /// </summary>
    internal static class LastRequestData
    {
        public static ActionExecutedContext ActionExecutedContext { get; set; }
        public static ResultExecutedContext ResultExecutedContext { get; set; }
        public static HttpSessionState HttpSessionState { get; set; }
        public static HttpResponse Response { get; set; }

        public static void Reset()
        {
            ActionExecutedContext = null;
            ResultExecutedContext = null;
            HttpSessionState = null;
            Response = null;
        }
    }
}