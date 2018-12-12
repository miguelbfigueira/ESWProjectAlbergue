using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ESWProjectAlbergue.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }

        [PersonalData]
        public DateTime BirthDate { get; set; }

        [PersonalData]
        public string Address { get; set; }

        [DataType(DataType.PostalCode)]
        public virtual string Postalcode { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}