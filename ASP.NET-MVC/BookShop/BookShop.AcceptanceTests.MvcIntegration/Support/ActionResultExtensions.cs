using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;

namespace BookShop.AcceptanceTests.Support
{
    public static class ActionResultExtensions
    {
        public static TModel Model<TModel>(this ActionResult result)
        {
#pragma warning disable 618,612
            Assert.IsInstanceOfType(typeof(ViewResult), result);
#pragma warning restore 618,612
            ViewResult viewResult = (ViewResult)result;
            Assert.IsNotNull(viewResult.ViewData.Model, "The action result does not contain a model");
#pragma warning disable 618,612
            Assert.IsInstanceOfType(typeof(TModel), viewResult.ViewData.Model, "The model in the action result is not of the right type");
#pragma warning restore 618,612
            return (TModel) viewResult.ViewData.Model;
        }
    }
}
