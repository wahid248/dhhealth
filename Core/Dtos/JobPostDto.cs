using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Dtos
{
    public class JobPostDto
    {
        public int Id { get; set; }

        private string intro;
        public string Intro
        {
            get { return System.Web.HttpUtility.UrlDecode(intro); }
            set { intro = System.Web.HttpUtility.UrlEncode(value); }
        }
        public string Postion { get; set; }
        public int JobCode { get; set; }
        public string EmploymentType { get; set; }
        public string JobDescription { get; set; }
        public string JobSpecification { get; set; }

        private string applyProcess;
        public string ApplyProcess
        {
            get { return System.Web.HttpUtility.UrlDecode(applyProcess); }
            set { applyProcess = System.Web.HttpUtility.UrlEncode(value); }
        }
        public string JobLocation { get; set; }

        public DateTime DeadLine { get; set; }

        public bool IsActive { get; set; }

        public string[] JobDescriptionArr { get; set; }
        public string[] JobSpecificationArr { get; set; }
    }
}
