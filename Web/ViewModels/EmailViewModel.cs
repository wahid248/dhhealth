using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class EmailViewModel
    {
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Message { get; set; }
        public IFormFile Attachment { get; set; }
        public string jobName { get; set; }
        public string Email { get; set; }
        public string To { get; set; }
        public string Form { get; set; }
        public string Subject { get; set; }
        public string EmailTemplateName { get; set; }

    }
}
