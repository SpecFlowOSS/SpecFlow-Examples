using RestSharp;

namespace CommunityContentSubmissionPage.Test.Common
{
    public class RestClientProvider
    {
        public static RestClient GetRestClient()
        {
            var restClient = new RestClient(ConfigurationProvider.BaseAddress);
            return restClient;
        }
    }
}