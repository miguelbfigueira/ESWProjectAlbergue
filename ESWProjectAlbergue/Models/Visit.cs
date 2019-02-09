// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-07-2019
//
// Last Modified By : migue
// Last Modified On : 02-08-2019
// ***********************************************************************
// <copyright file="Visit.cs" company="ESWProjectAlbergue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    /// <summary>
    /// Class Visit.
    /// </summary>
    public class Visit
    {
        /// <summary>
        /// Gets or sets the visit identifier.
        /// </summary>
        /// <value>The visit identifier.</value>
        public int VisitId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the user to visit identifier.
        /// </summary>
        /// <value>The user to visit identifier.</value>
        [Display(Name = "Utilizador a Visitar")]
        public string UserToVisitId { get; set; }

        /// <summary>
        /// Gets or sets the user to visit.
        /// </summary>
        /// <value>The user to visit.</value>
        [Display(Name = "Utilizador a Visitar")]
        public virtual ApplicationUser UserToVisit { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        
       
    }
}
