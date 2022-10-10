using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class EmailTemplate : EntityBase
    {
        public Enums.EmailTemplate.EmailTemplates TemplateType { get; set; }
        public string TemplateName { get; set; }
        public string Body {get;set; }
     }
  }
