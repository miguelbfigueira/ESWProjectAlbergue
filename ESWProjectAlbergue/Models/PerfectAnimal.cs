using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class PerfectAnimal
    {

        public int PerfectAnimalId { get; set; }

        [Display(Name = "Tipo de Animal")]
        public EnumAnimalType Type { get; set; }

        [Display(Name = "Género")]
        public EnumGenderType Gender { get; set; }

        [Display(Name = "Raça")]
        public int BreedId { get; set; }

        [Display(Name = "Raça")]
        public AnimalBreed Breed { get; set; }

        [Display(Name = "Tamanho")]
        public EnumSize Size { get; set; }

        [Display(Name = "Idade")]
        public EnumAgeType Age { get; set; }

        [Display(Name = "Animal Adotado")]
        public int AnimalId { get; set; }

        public Animal Animal { get; set; }

        public int Percentagem { get; set; }
    }
}
