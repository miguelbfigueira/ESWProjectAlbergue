using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public enum EnumGenderType
    {
        [Display(Name = "Fêmea")]
        FEMALE,
        [Display(Name = "Macho")]
        MALE,
        [Display(Name = "Desconhecido")]
        UNKNOWN,


    }
}
