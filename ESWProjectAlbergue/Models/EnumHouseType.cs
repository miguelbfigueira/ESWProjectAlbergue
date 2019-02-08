// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-08-2019
//
// Last Modified By : migue
// Last Modified On : 02-08-2019
// ***********************************************************************
// <copyright file="EnumHouseType.cs" company="ESWProjectAlbergue">
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
    /// Enum EnumHouseType
    /// </summary>
    public enum EnumHouseType
    {
        /// <summary>
        /// The ap
        /// </summary>
        [Display(Name = "Apartamento")]
        AP,
        /// <summary>
        /// The vi
        /// </summary>
        [Display(Name = "Vivenda")]
        VI,
        /// <summary>
        /// The ou
        /// </summary>
        [Display(Name = "Outra.")]
        OU,
    }
}
