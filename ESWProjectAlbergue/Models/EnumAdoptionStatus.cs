using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
            public enum EnumAdoptionStatus
        {
            [Display(Name = "Aceite")]
            ACCEPTED,
            [Display(Name = "Pendente")]
            PENDING,
            [Display(Name = "Recusado")]
            REFUSED

        }
    
}
