using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class Image : EntityBase
    {
        public string ImageUrl { get; set; }
        public string BottomText { get; set; }
        public string Album { get; set; }
        public IEnumerable<Section> Sections { get; set; }
        public ApplicationUser User { get; set; }
        public IEnumerable<Page> PageBaners { get; set; }
    }
}
