﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssignment.Domain.Models.DomainModels;

namespace TestAssignment.Domain.Context
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext() : base("DefaultConnection")
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Suplier> Supliers { get; set; }
        public DbSet<User> Users { get; set; } 
    }
}
