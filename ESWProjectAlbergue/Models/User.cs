using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class User : IdentityUser

    {
        public int ID { get; set; }
      

        [MinLength(9)]
        [MaxLength(9)]
        [Range(0, int.MaxValue, ErrorMessage = "Numero tem que ter 9 digitos")]
        public string Contact { get; set; }

      
       

    }
}
