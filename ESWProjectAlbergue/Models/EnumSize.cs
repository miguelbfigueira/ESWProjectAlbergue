// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-07-2019
//
// Last Modified By : migue
// Last Modified On : 01-21-2019
// ***********************************************************************
// <copyright file="EnumSize.cs" company="ESWProjectAlbergue">
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
    /// Enum EnumSize
    /// </summary>
    public enum EnumSize
    {
        /// <summary>
        /// The giant
        /// </summary>
        [Display(Name = "Gigante")]
        GIANT,
        /// <summary>
        /// The big
        /// </summary>
        [Display(Name = "Grande")]
        BIG,
        /// <summary>
        /// The medium
        /// </summary>
        [Display(Name = "Médio")]
        MEDIUM,
        /// <summary>
        /// The small
        /// </summary>
        [Display(Name = "Pequeno")]
        SMALL,
        /// <summary>
        /// The verysmall
        /// </summary>
        [Display(Name = "Muito Pequeno")]
        VERYSMALL,

    }
}
