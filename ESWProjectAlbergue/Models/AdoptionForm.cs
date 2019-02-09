// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-07-2019
//
// Last Modified By : migue
// Last Modified On : 02-08-2019
// ***********************************************************************
// <copyright file="AdoptionForm.cs" company="ESWProjectAlbergue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    /// <summary>
    /// Class AdoptionForm.
    /// </summary>
    public class AdoptionForm
    {
        /// <summary>
        /// Gets or sets the adoption form identifier.
        /// </summary>
        /// <value>The adoption form identifier.</value>
        [Display(Name = "Nº de Pedido")]
        public int AdoptionFormId { get; set; }

        /// <summary>
        /// Gets or sets the animal identifier.
        /// </summary>
        /// <value>The animal identifier.</value>
        [Display(Name = "Animal Para Adotar")]
        public int AnimalId { get; set; }

        /// <summary>
        /// Gets or sets the animal.
        /// </summary>
        /// <value>The animal.</value>
        public virtual Animal Animal { get; set; }

        /// <summary>
        /// Gets or sets the application user identifier.
        /// </summary>
        /// <value>The application user identifier.</value>
        [Display(Name = "Adotante")]
        public string ApplicationUserId { get; set; }

        /// <summary>
        /// Gets or sets the application user.
        /// </summary>
        /// <value>The application user.</value>
        public virtual ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        [Display(Name = "Data de Pedido")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the cc.
        /// </summary>
        /// <value>The cc.</value>
        [Display(Name = "Nº Cartão Cidadão")]
        public int Cc { get; set; }

        /// <summary>
        /// Gets or sets the job.
        /// </summary>
        /// <value>The job.</value>
        [Display(Name = "Profissão")]
        public string Job { get; set; }

        /// <summary>
        /// Gets or sets the more animals.
        /// </summary>
        /// <value>The more animals.</value>
        [Display(Name = "Possui mais animais em casa?")]
        public Boolean MoreAnimals { get; set; }

        /// <summary>
        /// Gets or sets the how many.
        /// </summary>
        /// <value>The how many.</value>
        [Display(Name = "Se sim, quantos?")]
        public string HowMany { get; set; }

        /// <summary>
        /// Gets or sets the animal types.
        /// </summary>
        /// <value>The animal types.</value>
        [Display(Name = "Se sim, que espécies?")]
        public string AnimalTypes { get; set; }

        /// <summary>
        /// Gets or sets the financially stable.
        /// </summary>
        /// <value>The financially stable.</value>
        [Display(Name = "É financeiramente estável?")]
        public Boolean FinanciallyStable { get; set; }

        /// <summary>
        /// Gets or sets the type of the house.
        /// </summary>
        /// <value>The type of the house.</value>
        [Display(Name = "Mora em que tipo de habitação?")]
        public EnumHouseType HouseType { get; set; }

        /// <summary>
        /// Gets or sets the number of bedrooms.
        /// </summary>
        /// <value>The number of bedrooms.</value>
        [Display(Name = "A sua habitação possui quantas divisões?")]
        public int NumberOfBedrooms { get; set; }

        /// <summary>
        /// Gets or sets the number of people.
        /// </summary>
        /// <value>The number of people.</value>
        [Display(Name = " Quantas pessoas constituem o seu agregado familiar?")]
        public int NumberOfPeople { get; set; }

        /// <summary>
        /// Gets or sets the animal travel.
        /// </summary>
        /// <value>The animal travel.</value>
        [Display(Name = "Quando viajar, onde pensa deixar o animal?")]
        public string AnimalTravel { get; set; }

        /// <summary>
        /// Gets or sets the leave house.
        /// </summary>
        /// <value>The leave house.</value>
        [Display(Name = "Se mudar de residência o que fará com o animal?")]
        public EnumLeaveHouse LeaveHouse { get; set; }

        /// <summary>
        /// Gets or sets the conscious.
        /// </summary>
        /// <value>The conscious.</value>
        [Display(Name = "Tem consciência de que um animal pode viver até aos 10, 15, 18 anos? E que ao adoptá-lo, torna-se responsável por ele durante a sua vida toda ? ")]
        public Boolean Conscious { get; set; }


    }

}


