using System.Net.Http;
using System.Threading.Tasks;

namespace WebRequest
{
    public class WebClient
    {
        public async Task<HttpResponseMessage> Get(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetAsync(url);
            }
        }
    }
}
