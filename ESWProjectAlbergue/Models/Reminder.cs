// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-07-2019
//
// Last Modified By : migue
// Last Modified On : 02-08-2019
// ***********************************************************************
// <copyright file="Reminder.cs" company="ESWProjectAlbergue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    /// <summary>
    /// Class Reminder.
    /// </summary>
    public class Reminder
    {
        /// <summary>
        /// Gets or sets the reminder identifier.
        /// </summary>
        /// <value>The reminder identifier.</value>
        public int ReminderId { get; set; }

        /// <summary>
        /// Gets or sets the user creater identifier.
        /// </summary>
        /// <value>The user creater identifier.</value>
        [DisplayName("Autor")]
        public string UserCreaterId { get; set; }

        /// <summary>
        /// Gets or sets the user creater.
        /// </summary>
        /// <value>The user creater.</value>
        [DisplayName("Autor")]
        public ApplicationUser UserCreater { get; set; }

        /// <summary>
        /// Gets or sets the date create.
        /// </summary>
        /// <value>The date create.</value>
        [DisplayName("Data Criação")]
        public DateTime DateCreate { get; set; }

        /// <summary>
        /// Gets or sets the date end.
        /// </summary>
        /// <value>The date end.</value>
        [DisplayName("Prazo para a Realização")]
        public DateTime DateEnd { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [DisplayName("Título")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [DisplayName("Descrição")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is event.
        /// </summary>
        /// <value><c>true</c> if this instance is event; otherwise, <c>false</c>.</value>
        [DisplayName("É um evento")]
        public bool IsEvent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is done.
        /// </summary>
        /// <value><c>true</c> if this instance is done; otherwise, <c>false</c>.</value>
        [DisplayName("Feito?")]
        public bool IsDone { get; set; }

        /// <summary>
        /// Gets or sets the user reminder identifier.
        /// </summary>
        /// <value>The user reminder identifier.</value>
        [DisplayName("Destinatário")]
        public string UserReminderId { get; set; }

        /// <summary>
        /// Gets or sets the user reminder.
        /// </summary>
        /// <value>The user reminder.</value>
        [DisplayName("Destinatário")]
        public ApplicationUser UserReminder { get; set; }
    }
}
