using Marketer.DomainClasses.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketer.DataLayer.Context
{
   public class MarketerDbContext:DbContext
    {
        public MarketerDbContext(DbContextOptions<MarketerDbContext> options) : base(options)
        {

        }
       
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source = .; Initial Catalog = Marketer; Integrated Security = true");
            }
            //base.OnConfiguring(optionsBuilder);
        }
    }
}
