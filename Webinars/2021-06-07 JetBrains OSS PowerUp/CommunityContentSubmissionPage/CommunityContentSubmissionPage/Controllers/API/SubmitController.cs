using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityContentSubmissionPage.Business.Infrastructure;
using CommunityContentSubmissionPage.Business.Logic;
using CommunityContentSubmissionPage.Database;
using CommunityContentSubmissionPage.Database.Model;
using CommunityContentSubmissionPage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommunityContentSubmissionPage.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmitController : ControllerBase
    {
        private readonly ISubmissionSaver _submissionSaver;
        private readonly IDatabaseContext _databaseContext;

        public SubmitController(ISubmissionSaver submissionSaver, IDatabaseContext databaseContext)
        {
            _submissionSaver = submissionSaver;
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SubmissionModel submissionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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

            return Ok();
        }

        [HttpGet]
        public async Task<List<SubmissionEntry>> Index()
        {
            return await _databaseContext.SubmissionEntries.ToListAsync();
        }
    }
}
