// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-07-2019
//
// Last Modified By : migue
// Last Modified On : 01-21-2019
// ***********************************************************************
// <copyright file="EnumFurType.cs" company="ESWProjectAlbergue">
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
    /// Enum EnumFurType
    /// </summary>
    public enum EnumFurType
    {
        /// <summary>
        /// The short
        /// </summary>
        [Display(Name = "Curto")]
        SHORT,
        /// <summary>
        /// The mixed
        /// </summary>
        [Display(Name = "Combinado")]
        MIXED,
        /// <summary>
        /// The thick
        /// </summary>
        [Display(Name = "Denso ou grosso")]
        THICK,
        /// <summary>
        /// The silky
        /// </summary>
        [Display(Name = "Sedoso")]
        SILKY,
        /// <summary>
        /// The curly
        /// </summary>
        [Display(Name = "Encaracolado")]
        CURLY,
        /// <summary>
        /// The long
        /// </summary>
        [Display(Name = "Longo")]
        LONG,
        

    }
}
