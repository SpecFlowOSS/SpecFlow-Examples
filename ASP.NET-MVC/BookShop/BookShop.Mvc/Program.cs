using Microsoft.Extensions.Hosting;

namespace BookShop.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new KestrelHostBuilder().CreateHostBuilder(args).Build().Run();
        }
    }
}
