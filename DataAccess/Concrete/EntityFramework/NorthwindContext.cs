using System;
using Core.Entities.Concrete;
using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;




namespace DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Server=localhost;Port=3306;Database=QRMenu;User=root;Password=amazon2022;";

                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30)))
                    ;
            }
            else { Console.WriteLine("couldnt find"); }
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }






    }
}


