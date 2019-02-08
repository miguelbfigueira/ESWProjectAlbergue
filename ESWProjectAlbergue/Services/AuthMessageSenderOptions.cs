// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 12-08-2018
//
// Last Modified By : migue
// Last Modified On : 12-08-2018
// ***********************************************************************
// <copyright file="AuthMessageSenderOptions.cs" company="ESWProjectAlbergue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Services
{
    /// <summary>
    /// Class AuthMessageSenderOptions.
    /// </summary>
    public class AuthMessageSenderOptions
    {
        /// <summary>
        /// Gets or sets the send grid user.
        /// </summary>
        /// <value>The send grid user.</value>
        public string SendGridUser { get; set; }
        /// <summary>
        /// Gets or sets the send grid key.
        /// </summary>
        /// <value>The send grid key.</value>
        public string SendGridKey { get; set; }
    }
}
