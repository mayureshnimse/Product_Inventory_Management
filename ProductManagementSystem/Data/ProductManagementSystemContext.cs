using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Model;

namespace ProductManagementSystem.Data
{
    public class ProductManagementSystemContext : DbContext
    {
        public ProductManagementSystemContext (DbContextOptions<ProductManagementSystemContext> options)
            : base(options)
        {
        }

        public DbSet<ProductManagementSystem.Model.Product> Product { get; set; } = default!;
    }
}
