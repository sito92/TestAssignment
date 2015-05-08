using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using TestAssignment.Domain.Models.DomainModels;
using TestAssignment.Models;

namespace TestAssignment.Domain.Context
{
    public class DataBaseContext : IdentityDbContext<ApplicationUser>
    {
        public DataBaseContext() : base("DefaultConnection")
        {
            
        }


        public static DataBaseContext Create()
        {
            return new DataBaseContext();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Suplier> Supliers { get; set; }
    }
}
