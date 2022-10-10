using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos
{
    public class EmailTemplateDto
    {
        public int Id { get; set; }
        public Enums.EmailTemplate.EmailTemplates TemplateType { get; set; }
        public string TemplateName { get; set; }
        public string Body { get; set; }
    }
}
