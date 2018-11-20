using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class District
    {
        public int DistrictId { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A {0} é obrigatória")]
        public string Description { get; set; }
    }
}
