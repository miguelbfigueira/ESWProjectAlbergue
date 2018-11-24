using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ESWProjectAlbergue.Areas.Identity.Data
{
    public class Utilizador : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }

        [PersonalData]
        public DateTime BirthDate { get; set; }

        [PersonalData]
        public string Address { get; set; }

        [DataType(DataType.PostalCode)]
        public virtual string Postalcode { get; set; }
    }
}