using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CommunityContentSubmissionPage.Business.Infrastructure;

namespace CommunityContentSubmissionPage.Models
{
    public class SubmissionModel
    {
        [DisplayName("Url to Content")]
        [Required]
        [Url]
        public string Url { get; set; }

        [DisplayName("Type of Content")]
        [Required]
        public string Type { get; set; }

        [DisplayName("Your Email address")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Description")]
        [Required]
        public string Description { get; set; }

        [BoolHasToBeTrue("You must accept the privacy policy!")]
        public bool AcceptPrivacyPolicy { get; set; }

        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }
    }
}
