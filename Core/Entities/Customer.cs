using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public bool IsSubscribed { get; set; }
    }
}
