using Microsoft.AspNetCore.Identity;
using ProjectName.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<IdentityUser> userManager)
        {
            var defaultUser = new IdentityUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Administrator1!");
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Designations.Any())
            {
                context.Designations.Add(new Designation
                {
                    Name = "Developer",
                    BasicSalary = "20000",
                    CreatedDate = DateTime.Now,
                    CreatedBy="rahul"
                });

                await context.SaveChangesAsync();
            }

            if (!context.Employees.Any())
            {
                context.Employees.Add(new Employee
                {
                    FirstName = "Rahul",
                    LastName = "Pal",
                    DesignationId = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "rahul"
                });

                await context.SaveChangesAsync();
            }

            //var user = new ApplicationUser
            //{
            //    UserName = "Email@email.com",
            //    NormalizedUserName = "email@email.com",
            //    Email = "Email@email.com",
            //    NormalizedEmail = "email@email.com",
            //    EmailConfirmed = true,
            //    LockoutEnabled = false,
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};

            //var roleStore = new RoleStore<IdentityRole>(context);

            //if (!context.Roles.Any(r => r.Name == "admin"))
            //{
            //    await roleStore.CreateAsync(new IdentityRole { Name = "admin", NormalizedName = "admin" });
            //}

            //if (!context.Users.Any(u => u.UserName == user.UserName))
            //{
            //    var password = new PasswordHasher<ApplicationUser>();
            //    var hashed = password.HashPassword(user, "password");
            //    user.PasswordHash = hashed;
            //    var userStore = new UserStore<ApplicationUser>(context);
            //    await userStore.CreateAsync(user);
            //    await userStore.AddToRoleAsync(user, "admin");
            //}

            //await context.SaveChangesAsync();
        }
    }
}
