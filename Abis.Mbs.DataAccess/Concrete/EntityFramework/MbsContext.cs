using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abis.Mbs.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Abis.Mbs.DataAccess.Concrete.EntityFramework
{
    public class MbsContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=abisstaj2019.database.windows.net;Database=mbs_2019;User ID=Abisstaj2019;Password=Chha4773;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobForm> JobForms { get; set; }
      


    }
}
