using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class ABehaviorType
    {
        // Chave primária 
        public int ABehaviorTypeId { get; set; }

        [Display(Name = "Designação")]
        [Required(ErrorMessage = "A {0} é obrigatória")]
        public string Designacao { get; set; }

        // Propriedade Navegacional
        public List<MainAnimal> Animals { get; set; }
    }
}
