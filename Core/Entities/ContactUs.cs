using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class ContactUs : EntityBase
    {
        public int CustomerId { get; set; }
        public string Message { get; set; }
        public Customer Customer { get; set; }
    }
}
