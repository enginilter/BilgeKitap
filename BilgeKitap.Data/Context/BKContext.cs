using BilgeKitap.Core.Entities.Concrete;
using BilgeKitap.Entity;
using BilgeKitap.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Data
{
    public class BKContext:DbContext
    {
        public BKContext()
        {

        }
        public BKContext(DbContextOptions<BKContext> options) : base(options) { }
        
   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-9OU8TTF;Database=BilgeKitapDB;Integrated Security=true");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
