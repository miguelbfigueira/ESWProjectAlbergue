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


        [DataType(DataType.Date)]
        [PersonalData]
        [CheckDateRange(ErrorMessage = "A data de nascimento tem de ser anterior a hoje.")] 
        public DateTime BirthDate { get; set; }

        [PersonalData]
        public string Address { get; set; }

        [DataType(DataType.PostalCode)]
        public virtual string Postalcode { get; set; }

        [PersonalData]
        public string Role { get; set; }

        //// Propriedade Navegacional
        //public List<MainAnimal> Animals { get; set; }

    }
}