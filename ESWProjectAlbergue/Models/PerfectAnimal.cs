// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-08-2019
//
// Last Modified By : migue
// Last Modified On : 02-08-2019
// ***********************************************************************
// <copyright file="PerfectAnimal.cs" company="ESWProjectAlbergue">
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
    /// Class PerfectAnimal.
    /// </summary>
    public class PerfectAnimal
    {

        /// <summary>
        /// Gets or sets the perfect animal identifier.
        /// </summary>
        /// <value>The perfect animal identifier.</value>
        public int PerfectAnimalId { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Display(Name = "Tipo de Animal")]
        public EnumAnimalType Type { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [Display(Name = "Género")]
        public EnumGenderType Gender { get; set; }

        /// <summary>
        /// Gets or sets the breed identifier.
        /// </summary>
        /// <value>The breed identifier.</value>
        [Display(Name = "Raça")]
        public int BreedId { get; set; }

        /// <summary>
        /// Gets or sets the breed.
        /// </summary>
        /// <value>The breed.</value>
        [Display(Name = "Raça")]
        public AnimalBreed Breed { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        [Display(Name = "Tamanho")]
        public EnumSize Size { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>The age.</value>
        [Display(Name = "Idade")]
        public EnumAgeType Age { get; set; }

        /// <summary>
        /// Gets or sets the animal identifier.
        /// </summary>
        /// <value>The animal identifier.</value>
        [Display(Name = "Animal Adotado")]
        public int AnimalId { get; set; }

        /// <summary>
        /// Gets or sets the animal.
        /// </summary>
        /// <value>The animal.</value>
        public Animal Animal { get; set; }

        /// <summary>
        /// Gets or sets the percentagem.
        /// </summary>
        /// <value>The percentagem.</value>
        public int Percentagem { get; set; }
    }
}
