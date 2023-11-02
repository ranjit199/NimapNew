using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Project_ProductMaster.Models
{
    public class ServiceContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
      
        public DbSet<Product> Products { get; set; }

        
    }
}