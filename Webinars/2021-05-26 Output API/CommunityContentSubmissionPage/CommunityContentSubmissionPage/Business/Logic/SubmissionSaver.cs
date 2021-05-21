using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityContentSubmissionPage.Business.Infrastructure;
using CommunityContentSubmissionPage.Database;
using CommunityContentSubmissionPage.Database.Model;

namespace CommunityContentSubmissionPage.Business.Logic
{
    public interface ISubmissionSaver
    {
        Task Save(SubmissionEntry submissionEntry);
    }

    public class SubmissionSaver : ISubmissionSaver
    {
        private readonly IDatabaseContext _databaseContext;

        public SubmissionSaver(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task Save(SubmissionEntry submissionEntry)
        {
            await _databaseContext.SubmissionEntries.AddAsync(submissionEntry);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
