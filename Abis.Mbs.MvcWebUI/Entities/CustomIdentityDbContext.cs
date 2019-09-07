using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Abis.Mbs.MvcWebUI.Areas.User.Models;
using Abis.Mbs.Entities.Concrete;

namespace Abis.Mbs.MvcWebUI.Entities
{
    public class CustomIdentityDbContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, string>
    {
        public CustomIdentityDbContext(DbContextOptions<CustomIdentityDbContext> options) : base(options)
        {

        }
        public DbSet<Abis.Mbs.MvcWebUI.Areas.User.Models.UserProfileUpdateViewModel> UserProfileUpdateViewModel { get; set; }
        public DbSet<Abis.Mbs.Entities.Concrete.UserProfile> UserProfile { get; set; }
    }
}
