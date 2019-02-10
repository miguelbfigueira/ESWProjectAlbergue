// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-07-2019
//
// Last Modified By : migue
// Last Modified On : 01-18-2019
// ***********************************************************************
// <copyright file="ApplicationUser.cs" company="ESWProjectAlbergue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ESWProjectAlbergue.Models
{
    /// <summary>
    /// Class ApplicationUser.
    /// Implements the <see cref="Microsoft.AspNetCore.Identity.IdentityUser" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUser" />
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [PersonalData]
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        [DataType(DataType.Date)]
        [PersonalData]
        [CheckDateRange(ErrorMessage = "A data de nascimento tem de ser anterior a hoje.")] 
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        [PersonalData]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the postalcode.
        /// </summary>
        /// <value>The postalcode.</value>
        [DataType(DataType.PostalCode)]
        public virtual string Postalcode { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>The role.</value>
        [PersonalData]
        public string Role { get; set; }

            }
}