using DriveMoto.Models;
using DriveMoto.Models.DTOs;
using DriveMoto.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DriveMoto.DataBase
{
    public class APIDbContext : IdentityDbContext<User>
    {
        public APIDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .HasOne(t => t.Client)
                .WithMany(t => t.CartItems)
                .HasForeignKey(t => t.CleantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
                     .HasOne(t => t.Product)
                     .WithMany(t => t.CartItems)
                     .HasForeignKey(t => t.ProductId)
                     .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }


    }

}
