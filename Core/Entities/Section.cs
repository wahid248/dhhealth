using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class Section : EntityBase
    {
        public byte SectionOrder { get; set; }
        public string TitleSmall { get; set; }
        public string TitleLarge { get; set; }
        public bool TitleLargeOnTop { get; set; }
        public string Content { get; set; }
        public string CustomCss { get; set; }
        public int? SectionTypeId { get; set; }//nullable
        public int? ParentSectionId { get; set; } //nullable
        public int? ImageId { get; set; } //nullable

#nullable enable
        [ForeignKey("ParentSectionId")]
        public Section? ParentSection { get; set; }
        public Image? Image { get; set; }
#nullable disable

        public ApplicationUser User { get; set; }
        public IEnumerable<PageSections> PageSections { get; set; }



    }
}
