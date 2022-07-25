using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace Mobiliva.DataAccess.Data
{
    public class MobilivaDbContext : DbContext
    {
        public MobilivaDbContext(DbContextOptions<MobilivaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < 100; i++)
            {
                modelBuilder.Entity<Product>().HasData(
                new Faker<Product>()
                    .RuleFor(c => c.Id, f => f.Random.Number(111111111, 999999999))
                    .RuleFor(c => c.Description, f => f.Lorem.Paragraph(1))
                    .RuleFor(c => c.Status, f => f.Random.Word())
                    .RuleFor(c => c.UnitPrice, f => f.Random.Number(1, 50000))
                    .RuleFor(c => c.Unit, f => f.Random.Number(0, 999))
                    .RuleFor(c => c.Category, f => f.Commerce.Categories(1).First())
                    .RuleFor(c => c.CreatedDate, f => f.Date.Past())
                    .RuleFor(c => c.CreatedBy, f => f.Person.FirstName)
                    .RuleFor(c => c.UpdatedDate, f => f.Date.Past())
                    .RuleFor(c => c.UpdatedBy, f => f.Person.FirstName));
            }



        }
        

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}
