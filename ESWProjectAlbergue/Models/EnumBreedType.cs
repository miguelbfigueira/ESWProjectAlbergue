using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public enum EnumBreedType
    {
        [Display(Name = "Husky")]
        HUSKY,  
   [Display(Name = "Beagle")]
        BEAGLE,  
   [Display(Name = "Great Dane")]
        GREATDANE,
   [Display(Name = "Outra")]
        OTHER,

    }
    
}
