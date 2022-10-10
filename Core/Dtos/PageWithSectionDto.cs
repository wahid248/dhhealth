using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos
{
    public class PageWithSectionDto
    {
        public PageDto Page { get; set; }
        public SectionDto Section { get; set; }
    }
}
