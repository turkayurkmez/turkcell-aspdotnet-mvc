using eshop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.DataAccess.Data
{
    public class TurkcellDbContext : DbContext
    {
        /*
         * POCO (POJO)
         * 
         */
        public TurkcellDbContext(DbContextOptions<TurkcellDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //   // optionsBuilder.UseSqlServer("Data Source=(localdb)\\Mssqllocaldb;Initial Catalog=TurkcellShop;Integrated Security=True;Encrypt=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired()
                                                                .HasMaxLength(100);

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>().HasData(new Category() { Id = 1, Name = "Elektronik" },
                                                    new Category() { Id = 2, Name = "Tekstil" },
                                                    new Category() { Id = 3, Name = "Kırtasiye" }
                                                   );

            modelBuilder.Entity<Product>().HasData(
                                                     new Product() { Id = 1, Name = "Dell XPS 13", Description = "32 GB Ram", CategoryId = 1, Price = 83200, DiscountRate = 0.05m, Stock = 150 },
                                                       new Product() { Id = 2, Name = "Tişört", Description = "Tşört işte", CategoryId = 2, Price = 200, DiscountRate = 0.15m, Stock = 350 },
                                                       new Product() { Id = 3, Name = "Defter seti", Description = "Öğrencilerin ihtiyacı", CategoryId = 3, Price = 150, DiscountRate = 0.25m, Stock = 150 }
                                                  );

            base.OnModelCreating(modelBuilder);
        }
    }
}
