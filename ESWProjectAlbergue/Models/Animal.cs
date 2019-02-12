// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-07-2019
//
// Last Modified By : migue
// Last Modified On : 01-22-2019
// ***********************************************************************
// <copyright file="Animal.cs" company="ESWProjectAlbergue">
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
    /// Class Animal.
    /// </summary>
    public class Animal
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Display(Name = "Nº de Registo")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Display(Name = "Nome")]
        [StringLength(40, ErrorMessage = "Nome não pode conter mais de 30 letras")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the animal.
        /// </summary>
        /// <value>The type of the animal.</value>
        [Display(Name = "Tipo de Animal")]
        public EnumAnimalType AnimalType { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [Display(Name = "Género")]
        public EnumGenderType Gender { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

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
        /// Gets or sets the type of the size.
        /// </summary>
        /// <value>The type of the size.</value>
        [Display(Name = "Tamanho")]
        public EnumSize SizeType { get; set; }

        /// <summary>
        /// Gets or sets the type of the fur.
        /// </summary>
        /// <value>The type of the fur.</value>
        [Display(Name = "Tipo de Pêlo")]
        public EnumFurType FurType  { get; set; }

        /// <summary>
        /// Gets or sets the type of the age.
        /// </summary>
        /// <value>The type of the age.</value>
        [Display(Name = "Idade")]
        public EnumAgeType AgeType { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the type of the behavior.
        /// </summary>
        /// <value>The type of the behavior.</value>
        [Display(Name = "Comportamento")]
        public EnumBehaviorType BehaviorType { get; set; }

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        /// <value>The photo.</value>
        [Display(Name = "Fotografia")]
        public byte[] Photo { get; set; }

        /// <summary>
        /// Gets or sets the adopted.
        /// </summary>
        /// <value>The adopted.</value>
        [Display(Name = "Adotado")]
        public Boolean Adopted { get; set; }



        


    }
}
