// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-07-2019
//
// Last Modified By : migue
// Last Modified On : 02-08-2019
// ***********************************************************************
// <copyright file="AdoptionFile.cs" company="ESWProjectAlbergue">
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
    /// Class AdoptionFile.
    /// </summary>
    public class AdoptionFile
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Display(Name = "Nº de Ficha")]
        public int Id { get; set; }

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
        [Display(Name = "Data de Adoção")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [Display(Name = "Estado do Pedido")]
        public EnumAdoptionStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        [Display(Name = "Formulário Pedido")]
        public int OrderId { get; set; }


    }
}
