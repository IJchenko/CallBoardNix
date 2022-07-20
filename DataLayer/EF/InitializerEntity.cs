using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EF
{
    public static class InitializerEntity
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string AdminName = "Admin";
            string AdminSurname = "Admin";
            string AdminStatus = "Admin";
            string AdminPassword = "Admin_1";
            if (await roleManager.FindByNameAsync("Admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if(await roleManager.FindByNameAsync("Worker") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Worker"));
            }
            if(await roleManager.FindByNameAsync("Employer") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Employer"));
            }
            if(await userManager.FindByNameAsync("Admin")==null)
            {
                User admin = new User() { Name = AdminName, 
                Surname = AdminSurname, Status = AdminStatus, UserName = AdminName, EmailConfirmed = true };
                IdentityResult result = await userManager.CreateAsync(admin, AdminPassword);
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
