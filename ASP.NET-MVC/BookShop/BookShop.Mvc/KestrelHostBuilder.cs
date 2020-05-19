using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BookShop.Mvc
{
    public class KestrelHostBuilder
    {
        public IHostBuilder CreateHostBuilder(string[] args, string? hostname = null, string? webRoot = null)    
        {
            return Host.CreateDefaultBuilder(args)
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