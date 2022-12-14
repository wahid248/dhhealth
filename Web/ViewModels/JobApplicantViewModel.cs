using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Web.Attributes;
using Web.Utilities;

namespace Web.ViewModels
{
    public class JobApplicantViewModel
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

        public IFormFile Attachment { get; set; }

        public string JobName { get; set; }
    }
}
