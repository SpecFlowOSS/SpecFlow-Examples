using System.Collections.Generic;

namespace CommunityContentSubmissionPage.Models.API
{
    public class AvailableTypesModel
    {
        public List<string> Types { get; set; }
        public string SelectedType { get; set; }
    }
}