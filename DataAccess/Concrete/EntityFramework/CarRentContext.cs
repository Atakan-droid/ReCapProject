using CORE.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Veri tabanı olan CarRentContext e bağlandık.
   public class CarRentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Bağlantı yeri önemli doğru girmeliydik
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CarRent;Trusted_Connection=true");
        }

        //oluşturduğumuz sınıfları veri tabanında ki tablolarla bağdaştırdık.
        public DbSet<Car> Car { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<CORE.Entities.Concrete.User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }



    }
}
