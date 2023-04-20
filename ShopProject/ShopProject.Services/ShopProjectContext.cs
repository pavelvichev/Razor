using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopProject.Models;

namespace ShopProject.Services
{
    public class ShopProjectContext : DbContext
    {
        public ShopProjectContext(DbContextOptions<ShopProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
