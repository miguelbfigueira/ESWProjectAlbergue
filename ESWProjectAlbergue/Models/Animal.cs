using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Tipo")]
        public EnumAnimalType AnimalType { get; set; }

        [DisplayName("Género")]
        public EnumGenderType Gender { get; set; }

        [DisplayName("Data Nascimento")]
        [DataType(DataType.Date)]
        [CheckDateRange(ErrorMessage = "A data de nascimento tem de ser anterior a hoje.")] 
        public DateTime BirthDate { get; set; }

        [DisplayName("Raça")]
        public EnumBreedType Breed { get; set; }

        [DisplayName("Tamanho")]
        public EnumSize SizeType { get; set; }

        [DisplayName("Tipo de Pelo")]
        public EnumFurType FurType  { get; set; }

        [DisplayName("Faixa Etária")]
        public EnumAgeType AgeType { get; set; }

        [DisplayName("Descrição")]
        public string Description { get; set; }

        [DisplayName("Comportamento")]
        public EnumBehaviorType BehaviorType { get; set; }


    }
}
