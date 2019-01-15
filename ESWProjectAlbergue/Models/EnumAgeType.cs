using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public enum EnumAgeType
    {
        [Display(Name = "Bebé")]
        BABY,
        [Display(Name = "Jovem")]
        YOUNG,
        [Display(Name = "Adulto")]
        ADULT,
        [Display(Name = "Sénior")]
        SENIOR
        
    }
}
