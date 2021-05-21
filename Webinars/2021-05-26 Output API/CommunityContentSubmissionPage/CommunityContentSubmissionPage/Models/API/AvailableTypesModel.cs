using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityContentSubmissionPage.Models.API
{
    public class AvailableTypesModel
    {
        public List<string> Types { get; set; }
        public string SelectedType { get; set; }
    }
}
