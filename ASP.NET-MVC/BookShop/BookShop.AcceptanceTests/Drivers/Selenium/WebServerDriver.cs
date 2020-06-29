using System;
using System.IO;
using System.Threading.Tasks;
using BookShop.Mvc;
using Microsoft.Extensions.Hosting;

namespace BookShop.AcceptanceTests.Drivers.Selenium
{
    public class WebServerDriver
    {
        private IHost _host;
        public string Hostname { get; private set; }

        public void Start()
        {
            Hostname = $"http://localhost:{GeneratePort()}";

            var hostBuilder = new KestrelHostBuilder();
            var builder = hostBuilder.CreateHostBuilder(new string[]{}, Hostname, Path.Combine(Path.GetDirectoryName(typeof(KestrelHostBuilder).Assembly.Location), "..", "..", "..", "..", "BookShop.Mvc","wwwroot"));
            _host = builder.Build();
            _host.StartAsync().ConfigureAwait(false);
        }


        public async Task Stop()
        {
            if (_host != null) await _host.StopAsync();
        }

        private int GeneratePort()
        {
            return new Random().Next(5000, 32000);
        }
    }
}