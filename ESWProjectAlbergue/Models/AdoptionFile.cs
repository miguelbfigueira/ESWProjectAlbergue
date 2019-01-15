using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class AdoptionFile
    {
        public int Id { get; set; }

        public Animal AdoptedAnimal { get; set; }

        public ApplicationUser Adopter { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        


    }
}
