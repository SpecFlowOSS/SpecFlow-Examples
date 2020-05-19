using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
