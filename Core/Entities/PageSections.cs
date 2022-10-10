using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class PageSections : EntityBase
    {
        public int PageId { get; set; }
        public int SectionId { get; set; }

        [ForeignKey("PageId")]
        public Page Page { get; set; }
        [ForeignKey("SectionId")]
        public Section Section { get; set; }
    }
}
