// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-07-2019
//
// Last Modified By : migue
// Last Modified On : 01-21-2019
// ***********************************************************************
// <copyright file="EnumAnimalType.cs" company="ESWProjectAlbergue">
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
    /// Enum EnumAnimalType
    /// </summary>
    public enum EnumAnimalType
    {
        /// <summary>
        /// The dog
        /// </summary>
        [Display(Name = "Cão")]
        DOG,
        /// <summary>
        /// The cat
        /// </summary>
        [Display(Name = "Gato")]
        CAT,
        /// <summary>
        /// The other
        /// </summary>
        
       

    }
}
