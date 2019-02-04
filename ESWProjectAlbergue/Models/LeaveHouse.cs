using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public enum LeaveHouse
    {
        [Display(Name = "Leva consigo")]
        LEVA,
        [Display(Name = "Devolve ao antigo dono ")]
        DEVOLVE,
        [Display(Name = "Entrega para outra pessoa")]
        DA,
        [Display(Name = "Abandona")]
        ABANDONA,


    }
}
