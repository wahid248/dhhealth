using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class PageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public bool IsEnabled { get; set; }
        
        public string SuccessMessage { get; set; }
        // for counting loop
        public int Index { get; set; }
    }
}
