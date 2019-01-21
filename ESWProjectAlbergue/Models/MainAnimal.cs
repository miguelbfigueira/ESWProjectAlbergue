using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class MainAnimal
    {
        public int MainAnimalId { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Tipo de Animal")]
        public int AnimalTypeId { get; set; }

        public AType AnimalType { get; set; }


        [Display(Name = "Género")]
        public int GenderTypeId { get; set; }

        public AGender GenderType { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A Data de Nascimento é obrigatória")]
        [RestrictedDate]
        public DateTime BirthDate { get; set; }


        [Display(Name = "Idade")]
        public int AnimalAgeTypeId { get; set; }

        public AAgeType AnimalAgeType { get; set; }


        [Display(Name = "Raça")]
        public int AnimalBreedId { get; set; }

        public ABreed AnimalBreed { get; set; }

        [Display(Name = "Tamanho")]
        public int AnimalSizeId { get; set; }

        public ASize AnimalSize { get; set; }


        [Display(Name = "Tipo de pêlo")]
        public int AnimalFurTypeId { get; set; }
        public AFurType AnimalFurType { get; set; }


        [Display(Name = "Comportamento")]
        public int AnimalBehaviorTypeId { get; set; }

        public ABehaviorType AnimalBehaviorType { get; set; }


        [Display(Name = "Descrição")]
        public string Description { get; set; }


        [Display(Name = "Adotado")]
        public Boolean Adopted { get; set; }


        

    }
}
