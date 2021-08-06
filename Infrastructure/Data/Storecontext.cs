using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class Storecontext : DbContext
    {
        public Storecontext(DbContextOptions<Storecontext> options) : base(options)
        {
        }

        public DbSet<Product> Products {get;set;}
        public DbSet<ProductBrand> ProductBrands {get;set;}

        public DbSet<ProductType> productTypes {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}