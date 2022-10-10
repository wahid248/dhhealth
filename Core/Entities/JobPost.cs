using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class JobPost : EntityBase
    {
        public string Intro { get; set; }
        public string Postion { get; set; }
        public int JobCode { get; set; }
        public string EmploymentType { get; set; }
        public string JobDescription { get; set; }
        public string JobSpecification { get; set; }
        public string ApplyProcess { get; set; }
        public string JobLocation { get; set; }
        public DateTime DeadLine { get; set; }
        public bool IsActive { get; set; }
    }
}
