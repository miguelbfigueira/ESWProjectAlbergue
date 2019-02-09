// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-07-2019
//
// Last Modified By : migue
// Last Modified On : 01-21-2019
// ***********************************************************************
// <copyright file="EnumGenderType.cs" company="ESWProjectAlbergue">
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
    /// Enum EnumGenderType
    /// </summary>
    public enum EnumGenderType
    {
        /// <summary>
        /// The female
        /// </summary>
        [Display(Name = "Fêmea")]
        FEMALE,
        /// <summary>
        /// The male
        /// </summary>
        [Display(Name = "Macho")]
        MALE,
        /// <summary>
        /// The unknown
        /// </summary>
        [Display(Name = "Desconhecido")]
        UNKNOWN,


    }
}
