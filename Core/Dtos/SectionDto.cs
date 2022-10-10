using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos
{
    public class SectionDto
    {
        public byte SectionOrder { get; set; }
        public int Id { get; set; }

        private string titleSmall;
        public string TitleSmall
        {
            get { return System.Web.HttpUtility.UrlDecode(titleSmall); }
            set { titleSmall = System.Web.HttpUtility.UrlEncode(value); }
        }
        public string TitleLarge { get; set; }
        public int? ImageId { get; set; }
        public int? SectionTypeId { get; set; }
        public bool TitleLargeOnTop { get; set; }

        private string content;
        public string Content
        {
            get { return System.Web.HttpUtility.UrlDecode(content); }
            set { content = System.Web.HttpUtility.UrlEncode(value); }
        }
        private string customCss;
        public string CustomCss
        {
            get { return System.Web.HttpUtility.UrlDecode(customCss); }
            set { customCss = System.Web.HttpUtility.UrlEncode(value); }
        }
        public int? ParentSectionId { get; set; }

        public ImageDto Image { get; set; }
    }
}
