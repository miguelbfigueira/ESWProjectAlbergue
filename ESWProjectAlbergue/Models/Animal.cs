using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class Animal
    {
        [Display(Name = "Nº de Registo")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Tipo de Animal")]
        public EnumAnimalType AnimalType { get; set; }

        [Display(Name = "Género")]
        public EnumGenderType Gender { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Raça")]
        public int BreedId { get; set; }

        [Display(Name = "Raça")]
        public AnimalBreed Breed { get; set; }

        [Display(Name = "Tamanho")]
        public EnumSize SizeType { get; set; }

        [Display(Name = "Tipo de Pêlo")]
        public EnumFurType FurType  { get; set; }

        [Display(Name = "Idade")]
        public EnumAgeType AgeType { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Comportamento")]
        public EnumBehaviorType BehaviorType { get; set; }

        [Display(Name = "Fotografia")]
        public string Photo { get; set; }

         [Display(Name = "Adotado")]
        public Boolean Adopted { get; set; }



        


    }
}
