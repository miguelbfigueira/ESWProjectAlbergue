using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class AdoptionFile
    {
        [Display(Name = "Nº de Ficha")]
        public int Id { get; set; }

        [Display(Name = "Animal Adotado")]
        public int AnimalId { get; set; }

        public Animal Animal { get; set; }

        [Display(Name = "Adotante")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Data de Adoção")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Estado do Pedido")]
        public EnumAdoptionStatus Status { get; set; }

        [Display(Name = "Formulário Pedido")]
        public int OrderId { get; set; }


    }
}
