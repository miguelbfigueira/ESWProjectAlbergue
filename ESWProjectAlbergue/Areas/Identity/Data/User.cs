using Microsoft.AspNetCore.Identity;
using System;

namespace ESWProjectAlbergue.Areas.Identity.Data
{
    public class User : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }

        [PersonalData]
        public DateTime BirthDate { get; set; }

        [PersonalData]
        public string Address { get; set; }

        
    }
}