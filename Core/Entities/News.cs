using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class News : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string LargeImageUrl{ get; set; }
        public string MediumImagUrl { get; set; }
        public string SmallImageUrl{ get; set; }

        [NotMapped]
        public Image Image { get; set; }
        public ApplicationUser User { get; set; }
    }
}
