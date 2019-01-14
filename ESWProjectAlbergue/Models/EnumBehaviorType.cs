using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public enum EnumBehaviorType
    {
        [Display(Name = "Muito Ativo")]
        VERYACTIVE,
        [Display(Name = "Ativo")]
        ACTIVE,
        [Display(Name = "Calmo")]
        CALM,
        [Display(Name = "Muito Calmo")]
        VERYCALM,
        [Display(Name = "Brincalhão")]
        PLAYFUL,




    }
}
