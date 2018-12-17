using System.Threading.Tasks;
using ESWProjectAlbergue.Models;

using Microsoft.AspNetCore.Identity;

namespace ESWProjectAlbergue.Models
{
    public class DbInitializer
    {
        // Sem gestão de utilizadores e papeis
        //public static void Initialize(ESWProjectAlbergueContext context)

        // Com gestão de utilizadores e papeis
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


            var admin = new ApplicationUser {Name = "admin", UserName = "admin@ips.pt", Email = "admin@ips.pt"};
            await userManager.CreateAsync(admin, "123456");
            var result = await userManager.CreateAsync(admin, "123456");
            if (result.Succeeded)
            {

                await userManager.AddToRoleAsync(admin, "admins");
                
            }

            context.SaveChanges();
        }
    }
}
