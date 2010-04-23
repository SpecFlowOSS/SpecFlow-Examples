using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Linq;

namespace MvcIntegrationTestFramework.Browsing
{
    internal class SimulatedWorkerRequest : SimpleWorkerRequest
    {
        private HttpCookieCollection cookies;
        private readonly string httpVerbName;
        private readonly NameValueCollection formValues;
        private readonly NameValueCollection headers;

        public SimulatedWorkerRequest(string page, string query, TextWriter output, HttpCookieCollection cookies, string httpVerbName, NameValueCollection formValues, NameValueCollection headers)
            : base(page, query, output)
        {
            this.cookies = cookies;
            this.httpVerbName = httpVerbName;
            this.formValues = formValues;
            this.headers = headers;
        }

        public override string GetHttpVerbName()
        {
            return httpVerbName;
        }

        public override string GetKnownRequestHeader(int index)
        {
            // Override "Content-Type" header for POST requests, otherwise ASP.NET won't read the Form collection
            if (index == 12)
                if (string.Equals(httpVerbName, "post", StringComparison.OrdinalIgnoreCase))
                    return "application/x-www-form-urlencoded";

            switch (index) {
                case 0x19:
                    return MakeCookieHeader();
                default:
                    if (headers == null)
                        return null;
                    return headers[GetKnownRequestHeaderName(index)];
            }
        }

        public override string GetUnknownRequestHeader(string name)
        {
            if(headers == null)
                return null;
            return headers[name];
        }

        public override string[][] GetUnknownRequestHeaders()
        {
            if (headers == null)
                return null;
            var unknownHeaders = from key in headers.Keys.Cast<string>()
                                 let knownRequestHeaderIndex = GetKnownRequestHeaderIndex(key)
                                 where knownRequestHeaderIndex < 0
                                 select new[] { key, headers[key] };
            return unknownHeaders.ToArray();
        }

        public override byte[] GetPreloadedEntityBody()
        {
            if(formValues == null)
                return base.GetPreloadedEntityBody();

            var sb = new StringBuilder();
            foreach (string key in formValues)
                sb.AppendFormat("{0}={1}&", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(formValues[key]));
            return Encoding.UTF8.GetBytes(sb.ToString());
        }

        private string MakeCookieHeader()
        {
            if((cookies == null) || (cookies.Count == 0))
                return null;
            var sb = new StringBuilder();
            foreach (string cookieName in cookies)
                sb.AppendFormat("{0}={1};", cookieName, cookies[cookieName].Value);
            return sb.ToString();
        }
    }
}