using Microsoft.EntityFrameworkCore;
using System;
using X96J2O_HFT_2021222.Models;

namespace X96J2O_HFT_2021222.Repository
{
    public class RentDbContext : DbContext
    {
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }

     

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                
                builder.UseLazyLoadingProxies().UseInMemoryDatabase("RentDb");
                    //.UseInMemoryDatabase("RentDb");
            }
        }
        public RentDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Car>(car => car
                .HasOne(car => car.Brand)
                .WithMany(brand => brand.Cars)
                .HasForeignKey(car => car.BrandId)
                .OnDelete(DeleteBehavior.Cascade));
            
            modelBuilder.Entity<Rent>(rent => rent
                .HasOne(rent => rent.Car)
                .WithMany(car=>car.Rents)
                .HasForeignKey(rent=>rent.CarId)
                .OnDelete(DeleteBehavior.Cascade));

            Brand opel = new Brand() { brandId = 1, Name = "Opel" };
            Brand suzuki = new Brand() { brandId = 2, Name = "Suzuki" };
            Brand volvo = new Brand() { brandId = 3, Name = "Volvo" };

            Car astra = new Car() { carId = 1, BrandId = opel.brandId, RentPrice = 10000, Model = "Opel Astra G"};
            Car corsa = new Car() { carId = 2, BrandId = opel.brandId, RentPrice = 15000, Model = "Opel Corsa-e" };
            Car vitara = new Car() { carId = 3, BrandId = suzuki.brandId, RentPrice = 25000, Model = "Suzuki Vitara" };
            Car celerio = new Car() { carId = 4, BrandId = suzuki.brandId, RentPrice = 15000, Model = "Suzuki Celerio" };
            Car s90 = new Car() { carId = 5, BrandId = volvo.brandId, RentPrice = 80000, Model = "Volvo s90" };
            Car v60 = new Car() { carId = 6, BrandId = volvo.brandId, RentPrice = 65000, Model = "volvo v60" };


            Rent sanya = new Rent() { rentId = 1,CarId=astra.carId ,FirstName = "Kis", LastName = "Sándor", Mail = "kissanya@gmail.com", Phone = "+3680323523",Out="2021.04.13", In="2021.04.20"};
            Rent bela = new Rent() { rentId = 2,CarId=corsa.carId, FirstName = "Nagy", LastName = "Bela", Mail = "nagybela@gmail.com", Phone = "+36768246010", Out = "2022.05.13", In = "2022.05.23" };
            Rent geza = new Rent() { rentId = 3,CarId = vitara.carId, FirstName = "Kis", LastName = "Laca", Mail = "kissanya@gmail.com", Phone = "+3612676212",Out ="2022.04.15", In = "2022.05.26" };
            Rent jozska = new Rent() { rentId =4,CarId = celerio.carId, FirstName = "Bauer", LastName = "Sándor", Mail = "bauer@gmail.com", Phone = "+36901233251",Out ="2022.04.12", In ="2021.04.20" };
            Rent fonokne = new Rent() { rentId = 5,CarId = v60.carId, FirstName = "Fonokne", LastName = "Julcsi", Mail = "fonokne@gmail.com", Phone = "+3680898765", Out ="2021.04.13", In = "2022.04.20" };
            Rent fonok2 = new Rent() { rentId = 7, CarId = v60.carId, FirstName = "Fonok2", LastName = "Ferenc", Mail = "foni2@gmail.com", Phone = "+36994532181", Out = "2021.01.01", In = null };
            Rent fonok = new Rent() { rentId = 6,CarId = s90.carId, FirstName = "Fonok", LastName = "Ferenc", Mail = "foni@gmail.com", Phone = "+36994532171", Out = "2021.01.01", In = null };
           

            modelBuilder.Entity<Brand>().HasData(opel, suzuki, volvo);
            modelBuilder.Entity<Car>().HasData(astra, vitara, corsa, celerio, s90, v60);
            modelBuilder.Entity<Rent>().HasData(sanya, bela, geza, jozska, fonokne, fonok,fonok2);
        }

    }
}
