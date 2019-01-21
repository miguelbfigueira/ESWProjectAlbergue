using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public EnumAnimalType AnimalType { get; set; }

        public EnumGenderType Gender { get; set; }

        [DataType(DataType.Date)]
        [CheckDateRange(ErrorMessage = "A data de nascimento tem de ser anterior a hoje.")] 
        public DateTime BirthDate { get; set; }

        public EnumBreedType Breed { get; set; }

        public EnumSize SizeType { get; set; }

        public EnumFurType FurType  { get; set; }

        public EnumAgeType AgeType { get; set; }

        public string Description { get; set; } 

        public EnumBehaviorType BehaviorType { get; set; }


    }
}
