using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESWProjectAlbergue.Areas.Identity.Data;
using ESWProjectAlbergue.Models;

using Microsoft.AspNetCore.Identity;

namespace MediatecaEst.Models
{
    public class DbInitializer
    {
        // Sem gestão de utilizadores e papeis
        //public static void Initialize(ESWProjectAlbergueContext context)

        // Com gestão de utilizadores e papeis
        public static async Task Initialize(ESWProjectAlbergueContext context, UserManager<Utilizador> userManager,
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
            //TESTE
            var adminsRole = new IdentityRole("admins");
            if (!await roleManager.RoleExistsAsync(adminsRole.Name))
            {
                await roleManager.CreateAsync(adminsRole);
            }

            var admin = new Utilizador {Name = "admin", UserName = "admin@ips.pt", Email = "admin@ips.pt"};
            var result = await userManager.CreateAsync(admin, "123456");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "admins");
            }

           
        }
    }
}
