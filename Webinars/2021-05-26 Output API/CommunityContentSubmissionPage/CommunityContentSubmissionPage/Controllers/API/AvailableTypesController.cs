using System.Collections.Generic;
using CommunityContentSubmissionPage.Models.API;
using Microsoft.AspNetCore.Mvc;

namespace CommunityContentSubmissionPage.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableTypesController : ControllerBase
    {
        private readonly List<string> _types = new List<string>()
        {
            "Blog Posts",
            "Books",
            "Presentations",
            "Videos",
            "Podcasts",
            "Examples"
        };

        [HttpGet]
        public AvailableTypesModel Get()
        {
            var model = new AvailableTypesModel()
            {
                Types = _types,
                SelectedType = "Blog Posts"
            };

            return model;
        }
    }
}
