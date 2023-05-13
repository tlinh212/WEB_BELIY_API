using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using WEB_BELIY_API.MODEL;

namespace WEB_BELIY_API.DATA
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions option) : base (option) { }

        #region DbSet
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }
        public DbSet<ImportBill> ImportBills { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Comment> Comments { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OrderDetail>().HasKey(o => new { o.IdOrder, o.IDPro});

            modelBuilder.Entity<OrderDetail>()
                        .HasOne<Order>(o => o.Orders)
                        .WithMany(p => p.OrderDetails)
                        .HasForeignKey(o => o.IdOrder)
                        .OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<OrderDetail>()
                        .HasOne<Product>(o => o.Product)
                        .WithMany(p => p.OrderDetails)
                        .HasForeignKey(p => p.IDPro)
                        .OnDelete((DeleteBehavior)ReferentialAction.NoAction); ;

            

            base.OnModelCreating(modelBuilder);
        }
    }
}
