using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class EmailLog : EntityBase
    {
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string To { get; set; }
        public string Form { get; set; }
        public string Subject { get; set; }
        public string EmailTemplateName { get; set; }
    }
}
