using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookShop.AcceptanceTests.Support
{
    public static class ActionResultExtensions
    {
        public static TModel Model<TModel>(this ActionResult result)
        {
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsNotNull(viewResult.ViewData.Model, "The action result does not contain a model");
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TModel), "The model in the action result is not of the right type");
            return (TModel) viewResult.ViewData.Model;
        }
    }
}
