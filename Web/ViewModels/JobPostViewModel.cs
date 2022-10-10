using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class JobPostViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Introduction is required", AllowEmptyStrings = false)]
        public string Intro { get; set; }

        [Required(ErrorMessage = "Postion Name is require", AllowEmptyStrings = false)]
        public string Postion { get; set; }

        [Required(ErrorMessage = "Job Code is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Job Code must be grater than 0")]
        public int JobCode { get; set; }

        //[Required(ErrorMessage = "Employment Type is required", AllowEmptyStrings = false)]
        public string EmploymentType { get; set; }

        [Required(ErrorMessage = "Job Description is required", AllowEmptyStrings = false)]
        public string JobDescription { get; set; }

        [Required(ErrorMessage = "Job Specification is required", AllowEmptyStrings = false)]
        public string JobSpecification { get; set; }

        [Required(ErrorMessage = "Apply Process is required", AllowEmptyStrings = false)]
        public string ApplyProcess { get; set; }

        [Required(ErrorMessage = "Job Location is required", AllowEmptyStrings = false)]
        public string JobLocation { get; set; }

        [Required(ErrorMessage = "Application Deadline is required")]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime DeadLine { get; set; }
        public bool IsActive { get; set; }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }


    }
}
