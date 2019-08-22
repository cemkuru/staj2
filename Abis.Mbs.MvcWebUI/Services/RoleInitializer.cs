using Abis.Mbs.MvcWebUI.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abis.Mbs.MvcWebUI.Services
{
    public static class RoleInitializer
    {
        public static async Task Initialize(RoleManager<CustomIdentityRole> roleManager)
        {
            if(!await roleManager.RoleExistsAsync("Admin"))
            {
                CustomIdentityRole role = new CustomIdentityRole
                {
                    Name = "Admin"
                };
                await roleManager.CreateAsync(role);
            } if(!await roleManager.RoleExistsAsync("mod"))
            {
                CustomIdentityRole role = new CustomIdentityRole
                {
                    Name = "mod"
                };
                await roleManager.CreateAsync(role);
            } if(!await roleManager.RoleExistsAsync("User"))
            {
                CustomIdentityRole role = new CustomIdentityRole
                {
                    Name = "User"
                };
                await roleManager.CreateAsync(role);
            } if(!await roleManager.RoleExistsAsync("Anonymous"))
            {
                CustomIdentityRole role = new CustomIdentityRole
                {
                    Name = "Anonymous"
                };
                await roleManager.CreateAsync(role);
            }
        }
    }
}
