using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BookShop.Mvc
{
    public class KestrelHostBuilder
    {
        public IHostBuilder CreateHostBuilder(string[] args, string hostname = null, string webRoot = null)    
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    if (hostname != null)
                    {
                        webBuilder.UseUrls(hostname);
                    }

                    if (webRoot != null)
                    {
                        webBuilder.UseWebRoot(webRoot);
                    }
                    
                });
        }
    }
}