using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.AcceptanceTests.Drivers.Integrated
{
    public static class ActionResultExtensions
    {
        public static TModel Model<TModel>(this ActionResult result)
        {
            return result.Should().NotBeNull()
                         .And.Subject.Should().BeAssignableTo<ViewResult>()
                         .Which.ViewData.Model.Should().NotBeNull()
                         .And.Subject.Should().BeAssignableTo<TModel>()
                         .Subject;
        }
    }
}
