using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Page : EntityBase
    {
        public string Name { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public bool IsEnabled { get; set; }
        public int? BannerId { get; set; }
        public IEnumerable<PageSections>  PageSections { get; set; }
        public Image Banner { get; set; }
    }
}
