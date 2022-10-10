using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Web.Attributes;
using Web.Utilities;

namespace Web.ViewModels
{
    public class ContactUsViewModel
    {
        [Required(ErrorMessage = "Name is required", AllowEmptyStrings = false)]
        [RegEx(RegExValidation.Name, ErrorMessage = "Not a valid Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone no. is required", AllowEmptyStrings = false)]
        [RegEx(RegExValidation.PhoneNo, ErrorMessage = "Not a valid Phone Number")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Email is required", AllowEmptyStrings = false)]
        [RegEx(RegExValidation.Email, ErrorMessage = "Not a valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required", AllowEmptyStrings = false)]
        [RegEx(RegExValidation.Message, RegexOptions.Singleline, ErrorMessage = "Unsupported character found")]
        public string Message { get; set; }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
    }
}
