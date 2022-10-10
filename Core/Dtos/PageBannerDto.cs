using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos
{
    public class PageBannerDto
    {
        public int PageId { get; set; }
        public string PageName { get; set; }
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
    }
}
