using System.ComponentModel.DataAnnotations;

namespace CommunityContentSubmissionPage.Database.Model
{
    public class SubmissionEntry
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public string Name { get; set; }
    }
}
