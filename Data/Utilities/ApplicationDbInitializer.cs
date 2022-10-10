using Core.Entities.Identity;
using Data.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utilities
{
    public class ApplicationDbInitializer
    {
        public static async Task SeedUserAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            var role = new IdentityRole("Superadmin");
            var user = new ApplicationUser()
            {
                FirstName = "Fatmonk",
                LastName = "Studio",
                Email = "wahid@fatmonk.studio",
                UserName = "fms24",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                CreatedBy = "SYSTEM",
                LockoutEnabled = false
            };


            if (!context.Roles.Any(r => r.Name == role.Name))
            {
                using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await roleManager.CreateAsync(role);
            }

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var hasher = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = hasher.HashPassword(user, "nothing1234#");

                using var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role.Name);
                }
            }
        }
    }
}