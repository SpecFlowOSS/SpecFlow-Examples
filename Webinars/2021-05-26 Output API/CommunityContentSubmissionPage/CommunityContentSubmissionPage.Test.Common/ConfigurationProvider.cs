using Microsoft.Extensions.Configuration;

namespace CommunityContentSubmissionPage.Test.Common
{
    public class ConfigurationProvider
    {
        public static IConfiguration LoadConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string BaseAddress => LoadConfiguration()["Product.Api:BaseAddress"];
    }
}