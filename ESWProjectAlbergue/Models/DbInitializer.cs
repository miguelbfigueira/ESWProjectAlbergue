// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-07-2019
//
// Last Modified By : migue
// Last Modified On : 01-21-2019
// ***********************************************************************
// <copyright file="DbInitializer.cs" company="ESWProjectAlbergue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;
using ESWProjectAlbergue.Models;

using Microsoft.AspNetCore.Identity;

namespace ESWProjectAlbergue.Models
{
    /// <summary>
    /// Class DbInitializer.
    /// </summary>
    public class DbInitializer
    {
        // Sem gestão de utilizadores e papeis
        //public static void Initialize(ESWProjectAlbergueContext context)

        // Com gestão de utilizadores e papeis
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="roleManager">The role manager.</param>
        /// <returns>Task.</returns>
        public static async Task Initialize(ESWProjectAlbergueContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            // Adicionar papeis e utilizadores com os gestores apropriados

            // Roles
            var usersRole = new IdentityRole("users");
            if (!await roleManager.RoleExistsAsync(usersRole.Name))
            {
                await roleManager.CreateAsync(usersRole);
            }

            var funcionarioRole = new IdentityRole("funcionarios");
            if(!await roleManager.RoleExistsAsync(funcionarioRole.Name))
            {
                await roleManager.CreateAsync(funcionarioRole);
            }
           
            var adminsRole = new IdentityRole("admins");
            if (!await roleManager.RoleExistsAsync(adminsRole.Name))
            {
                await roleManager.CreateAsync(adminsRole);
            }

            var voluntariosRole = new IdentityRole("voluntarios");
            if (!await roleManager.RoleExistsAsync(adminsRole.Name))
            {
                await roleManager.CreateAsync(voluntariosRole);
            }

            
    


            var admin = new ApplicationUser {Name = "admin", UserName = "admin@ips.pt", Email = "admin@ips.pt", EmailConfirmed = true};
    
            var result2 = await userManager.CreateAsync(admin, "Quinta_5");
            if (result2.Succeeded)
            {

                await userManager.AddToRoleAsync(admin, "admins");
                
            }

          

           

            context.SaveChanges();
        }
    }
}
