using Core.Abstruct.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Identity
{
    public class ApplicationUser : IdentityUser, IEntity<string>
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime? CreatedOn { get; set; }
        public virtual string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual string ModifiedBy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Image> Images { get; set; }
        public IEnumerable<Section> Sections { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
