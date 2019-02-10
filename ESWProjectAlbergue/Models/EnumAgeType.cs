// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-07-2019
//
// Last Modified By : migue
// Last Modified On : 01-21-2019
// ***********************************************************************
// <copyright file="EnumAgeType.cs" company="ESWProjectAlbergue">
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
    /// Enum EnumAgeType
    /// </summary>
    public enum EnumAgeType
    {
        /// <summary>
        /// The baby
        /// </summary>
        [Display(Name = "Bebé")]
        BABY,
        /// <summary>
        /// The young
        /// </summary>
        [Display(Name = "Jovem")]
        YOUNG,
        /// <summary>
        /// The adult
        /// </summary>
        [Display(Name = "Adulto")]
        ADULT,
        /// <summary>
        /// The senior
        /// </summary>
        [Display(Name = "Sénior")]
        SENIOR
        
    }
}
