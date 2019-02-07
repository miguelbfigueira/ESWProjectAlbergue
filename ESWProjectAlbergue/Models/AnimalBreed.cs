using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class AnimalBreed
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public EnumBehaviorType Behavior { get; set; }


    }
}
