using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class AdoptionForm
    {
        [Display(Name = "Nº de Pedido")]
        public int AdoptionFormId { get; set; }

        [Display(Name = "Animal Para Adotar")]
        public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; }

        [Display(Name = "Adotante")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Data de Pedido")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Nº Cartão Cidadão")]
        public int Cc { get; set; }

        [Display(Name = "Profissão")]
        public string Job { get; set; }

        [Display(Name = "Possui mais animais em casa?")]
        public Boolean MoreAnimals { get; set; }

        [Display(Name = "Se sim, quantos?")]
        public string HowMany { get; set; }

        [Display(Name = "Se sim, que espécies?")]
        public string AnimalTypes { get; set; }

        [Display(Name = "É financeiramente estável?")]
        public Boolean FinanciallyStable { get; set; }

        [Display(Name = "Mora em que tipo de habitação?")]
        public EnumHouseType HouseType { get; set; }

        [Display(Name = "A sua habitação possui quantas divisões?")]
        public int NumberOfBedrooms { get; set; }

        [Display(Name = " Quantas pessoas constituem o seu agregado familiar?")]
        public int NumberOfPeople { get; set; }

        [Display(Name = "Quando viajar, onde pensa deixar o animal?")]
        public string AnimalTravel { get; set; }

        [Display(Name = "Se mudar de residência o que fará com o animal?")]
        public EnumLeaveHouse LeaveHouse { get; set; }

        [Display(Name = "Tem consciência de que um animal pode viver até aos 10, 15, 18 anos? E que ao adoptá-lo, torna-se responsável por ele durante a sua vida toda ? ")]
        public Boolean Conscious { get; set; }


    }

}


