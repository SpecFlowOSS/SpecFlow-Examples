using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CommunityContentSubmissionPage
{
    public class KestrelHostBuilder
    {
        public IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}