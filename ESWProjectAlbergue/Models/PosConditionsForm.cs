using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class PosConditionsForm
    {
        public int Id { get; set; }

        public int AdoptionFileId {get; set;}

        public AdoptionFile AdoptionFile { get; set; }

        [Display(Name = "O animal apresenta sinais de maus tratos?")]
        public bool Answer1 { get; set; }

        [Display(Name = "O animal apresenta um aspeto saudável?")]
        public bool Answer2 { get; set; }

        [Display(Name = "A habitação apresenta as condições necessárias?")]
        public bool Answer3 { get; set; }

        [Display(Name = "O animal poderá continuar com o adotante?")]
        public bool result { get; set; }
    }
}
