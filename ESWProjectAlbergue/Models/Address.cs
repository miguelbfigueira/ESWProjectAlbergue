using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        [Display(Name = "Morada")]
        [Required(ErrorMessage = "A {0} é obrigatória")]
        public string Description { get; set; }


        public District District { get; set; }
    }
}
