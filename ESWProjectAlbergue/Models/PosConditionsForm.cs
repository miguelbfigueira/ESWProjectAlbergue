// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-07-2019
//
// Last Modified By : migue
// Last Modified On : 01-22-2019
// ***********************************************************************
// <copyright file="PosConditionsForm.cs" company="ESWProjectAlbergue">
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
    /// Class PosConditionsForm.
    /// </summary>
    public class PosConditionsForm
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the adoption file identifier.
        /// </summary>
        /// <value>The adoption file identifier.</value>
        public int AdoptionFileId {get; set;}

        /// <summary>
        /// Gets or sets the adoption file.
        /// </summary>
        /// <value>The adoption file.</value>
        public AdoptionFile AdoptionFile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PosConditionsForm"/> is answer1.
        /// </summary>
        /// <value><c>true</c> if answer1; otherwise, <c>false</c>.</value>
        [Display(Name = "O animal apresenta sinais de maus tratos?")]
        public bool Answer1 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PosConditionsForm"/> is answer2.
        /// </summary>
        /// <value><c>true</c> if answer2; otherwise, <c>false</c>.</value>
        [Display(Name = "O animal apresenta um aspeto saudável?")]
        public bool Answer2 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PosConditionsForm"/> is answer3.
        /// </summary>
        /// <value><c>true</c> if answer3; otherwise, <c>false</c>.</value>
        [Display(Name = "A habitação apresenta as condições necessárias?")]
        public bool Answer3 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PosConditionsForm"/> is result.
        /// </summary>
        /// <value><c>true</c> if result; otherwise, <c>false</c>.</value>
        [Display(Name = "O animal poderá continuar com o adotante?")]
        public bool result { get; set; }
    }
}
