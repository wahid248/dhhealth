using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos
{
    public class PageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public bool IsEnabled { get; set; }
    }
}
