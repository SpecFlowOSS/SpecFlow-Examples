using System.ComponentModel.DataAnnotations;

namespace DemoWebApp.Models
{
    public class UserModel
    {
        public const string RegexPattern = "^[a-zA-Z]+[0-9]+$";

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a username")]
        [StringLength(maximumLength: 50, MinimumLength = 8, ErrorMessage = "The username must be between 8 and 50 character")]
        [RegularExpression(pattern: RegexPattern, ErrorMessage = "The username must only contain letters and numbers")]
        public string? Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a password")]
        [StringLength(maximumLength: 50, MinimumLength = 8, ErrorMessage = "The password must be between 8 and 50 character")]
        [RegularExpression(pattern: RegexPattern, ErrorMessage = "The password must only contain letters and numbers")]
        public string? Password { get; set; }
    }
}
