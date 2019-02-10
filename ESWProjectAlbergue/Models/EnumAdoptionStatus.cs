// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-08-2019
//
// Last Modified By : migue
// Last Modified On : 02-08-2019
// ***********************************************************************
// <copyright file="EnumAdoptionStatus.cs" company="ESWProjectAlbergue">
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
    /// Enum EnumAdoptionStatus
    /// </summary>
    public enum EnumAdoptionStatus
        {
        /// <summary>
        /// The aceite
        /// </summary>
        [Display(Name = "Aceite")]
            ACEITE,
        /// <summary>
        /// The pendente
        /// </summary>
        [Display(Name = "Pendente")]
            PENDENTE,
        /// <summary>
        /// The recusado
        /// </summary>
        [Display(Name = "Recusado")]
            RECUSADO

        }
    
}
