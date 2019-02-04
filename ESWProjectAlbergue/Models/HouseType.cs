using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public enum HouseType
    {
        [Display(Name = "Apartamento")]
        AP,
        [Display(Name = "Vivenda")]
        VI,
        [Display(Name = "Outra.")]
        OU,
    }
}
