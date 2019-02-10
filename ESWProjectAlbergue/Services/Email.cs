// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 11-21-2018
//
// Last Modified By : migue
// Last Modified On : 01-06-2019
// ***********************************************************************
// <copyright file="Email.cs" company="ESWProjectAlbergue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Services
{
    /// <summary>
    /// Class Email.
    /// Implements the <see cref="Microsoft.AspNetCore.Identity.UI.Services.IEmailSender" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.UI.Services.IEmailSender" />
    public class Email : IEmailSender
    {
        // Our private configuration variables
        /// <summary>
        /// The host
        /// </summary>
        private string host;
        /// <summary>
        /// The port
        /// </summary>
        private int port;
        /// <summary>
        /// The enable SSL
        /// </summary>
        private bool enableSSL;
        /// <summary>
        /// The user name
        /// </summary>
        private string userName;
        /// <summary>
        /// The password
        /// </summary>
        private string password;

        // Get our parameterized configuration
        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="enableSSL">if set to <c>true</c> [enable SSL].</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        public Email(string host, int port, bool enableSSL, string userName, string password)
        {
            this.host = host;
            this.port = port;
            this.enableSSL = enableSSL;
            this.userName = userName;
            this.password = password;
        }

        /// <summary>
        /// Sends the email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="htmlMessage">The HTML message.</param>
        /// <returns>Task.</returns>
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = enableSSL
            };
            return client.SendMailAsync(
                new MailMessage(userName, email, subject, htmlMessage) { IsBodyHtml = true }
            );
        }
    }
}
