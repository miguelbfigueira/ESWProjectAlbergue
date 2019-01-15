using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public enum EnumAnimalType
    {
        [Display(Name = "Cão")]
        DOG,
        [Display(Name = "Gato")]
        CAT,
        [Display(Name = "Outro")]
        OTHER,
       

    }
}
