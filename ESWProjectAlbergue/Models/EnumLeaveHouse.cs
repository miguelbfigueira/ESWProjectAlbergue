// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-08-2019
//
// Last Modified By : migue
// Last Modified On : 02-08-2019
// ***********************************************************************
// <copyright file="EnumLeaveHouse.cs" company="ESWProjectAlbergue">
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
    /// Enum EnumLeaveHouse
    /// </summary>
    public enum EnumLeaveHouse
    {
        /// <summary>
        /// The leva
        /// </summary>
        [Display(Name = "Leva consigo")]
        LEVA,
        /// <summary>
        /// The devolve
        /// </summary>
        [Display(Name = "Devolve ao antigo dono ")]
        DEVOLVE,
        /// <summary>
        /// The da
        /// </summary>
        [Display(Name = "Entrega para outra pessoa")]
        DA,
        /// <summary>
        /// The abandona
        /// </summary>
        [Display(Name = "Abandona")]
        ABANDONA,


    }
}
