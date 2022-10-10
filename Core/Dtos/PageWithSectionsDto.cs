using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos
{
    public class PageWithSectionsDto
    {
        
        public PageDto Page { get; set; }
        public IEnumerable<SectionDto> Sections { get; set; }
        public IEnumerable<SectionDto> ParentSections { get; set; }
    }
}
