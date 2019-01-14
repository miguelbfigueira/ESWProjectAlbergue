using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public enum EnumFurType
    {
        [Display(Name = "Curto")]
        SHORT,
        [Display(Name = "Combinado")]
        MIXED,
        [Display(Name = "Denso ou grosso")]
        THICK,
        [Display(Name = "Sedoso")]
        SILKY,
        [Display(Name = "Encaracolado")]
        CURLY,
        [Display(Name = "Longo")]
        LONG,
        

    }
}
