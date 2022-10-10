using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class SectionViewModel
    {
        [Required(ErrorMessage = "Section Order is required")]
        [Range(1, byte.MaxValue, ErrorMessage = "Section Order must be greather than 0")]
        [DisplayName("Section Order")]
        public byte SectionOrder { get; set; }
        public int Id { get; set; }

        [DisplayName("Title Small")]
        public string TitleSmall { get; set; }

        [DisplayName("Title Large")]
        public string TitleLarge { get; set; }
        public int? ImageId { get; set; }
        public int? SectionTypeId { get; set; }

        public bool TitleLargeOnTop { get; set; }

        [DisplayName("Content")]
        public string Content { get; set; }
        [DisplayName("Custom Css")]
        public string CustomCss { get; set; }
    }
}
