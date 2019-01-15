using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public enum EnumSize
    {
        [Display(Name = "Gigante")]
        GIANT,
        [Display(Name = "Grande")]
        BIG,
        [Display(Name = "Médio")]
        MEDIUM,
        [Display(Name = "Pequeno")]
        SMALL,
        [Display(Name = "Muito Pequeno")]
        VERYSMALL,

    }
}
