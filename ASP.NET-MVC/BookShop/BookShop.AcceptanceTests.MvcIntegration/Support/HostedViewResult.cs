using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.AcceptanceTests.MvcIntegration.Support
{
    [Serializable]
    public class HostedViewResult<TModel> where TModel: class 
    {
        public string ResponseText { get; set; }
        public TModel Model { get; set; }

        public HostedViewResult(string responseText, TModel model)
        {
            ResponseText = responseText;
            Model = model;
        }
    }
}
