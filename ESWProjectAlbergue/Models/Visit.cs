using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class Visit
    {
        public int VisitId { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Utilizador a Visitar")]
        public string UserToVisitId { get; set; }

        [Display(Name = "Utilizador a Visitar")]
        public virtual ApplicationUser UserToVisit { get; set; }

        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        
       
    }
}
