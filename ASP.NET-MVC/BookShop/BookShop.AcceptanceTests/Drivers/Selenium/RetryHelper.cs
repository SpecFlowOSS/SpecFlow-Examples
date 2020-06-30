using System;
using System.Threading;
using Polly;

namespace BookShop.AcceptanceTests.Drivers.Selenium
{
    class RetryHelper
    {
        public static void WaitFor(Func<Boolean> func)
        {
            var retryPolicy = Policy.Handle<Exception>()
                .Retry(10, (exception, i) =>
                {
                    Thread.Sleep(1000);
                });


            retryPolicy.Execute(func);
        }
    }
}
