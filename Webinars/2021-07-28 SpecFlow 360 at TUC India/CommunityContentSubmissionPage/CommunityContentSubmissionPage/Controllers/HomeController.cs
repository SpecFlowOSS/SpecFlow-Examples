using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CommunityContentSubmissionPage.Business.Infrastructure;
using CommunityContentSubmissionPage.Business.Logic;
using CommunityContentSubmissionPage.Database.Model;
using Microsoft.AspNetCore.Mvc;
using CommunityContentSubmissionPage.Models;

namespace CommunityContentSubmissionPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISubmissionSaver _submissionSaver;

        public HomeController(ISubmissionSaver submissionSaver)
        {
            _submissionSaver = submissionSaver;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new SubmissionModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(SubmissionModel submissionModel)
        {
            if (!ModelState.IsValid)
            {
                return View(submissionModel);
            }

            var submission = new SubmissionEntry()
            {
                Url = submissionModel.Url,
                Type = submissionModel.Type,
                Email = submissionModel.Email,
                Description = submissionModel.Description,
                Name = submissionModel.Name
            };

            await _submissionSaver.Save(submission);

            return RedirectToAction("Success");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
    }
}
