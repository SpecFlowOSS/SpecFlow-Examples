using CommunityContentSubmissionPage.Business.Infrastructure;
using Microsoft.Extensions.Hosting;

namespace CommunityContentSubmissionPage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new KestrelHostBuilder().CreateHostBuilder(args)
                .Build()                                 
                .Run();
        }
    }
}