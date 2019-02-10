// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-07-2019
//
// Last Modified By : migue
// Last Modified On : 01-21-2019
// ***********************************************************************
// <copyright file="EnumBehaviorType.cs" company="ESWProjectAlbergue">
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
    /// Enum EnumBehaviorType
    /// </summary>
    public enum EnumBehaviorType
    {
        /// <summary>
        /// The veryactive
        /// </summary>
        [Display(Name = "Muito Ativo")]
        VERYACTIVE,
        /// <summary>
        /// The active
        /// </summary>
        [Display(Name = "Ativo")]
        ACTIVE,
        /// <summary>
        /// The calm
        /// </summary>
        [Display(Name = "Calmo")]
        CALM,
        /// <summary>
        /// The verycalm
        /// </summary>
        [Display(Name = "Muito Calmo")]
        VERYCALM,
        /// <summary>
        /// The playful
        /// </summary>
        [Display(Name = "Brincalhão")]
        PLAYFUL,




    }
}
