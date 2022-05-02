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

            Brand opel = new Brand() { Id = 1, Name = "Opel" };
            Brand suzuki = new Brand() { Id = 2, Name = "Suzuki" };
            Brand volvo = new Brand() { Id = 3, Name = "Volvo" };

            Car astra = new Car() { Id = 1, BrandId = opel.Id, RentPrice = 10000, Model = "Opel Astra G"};
            Car corsa = new Car() { Id = 2, BrandId = opel.Id, RentPrice = 15000, Model = "Opel Corsa-e" };
            Car vitara = new Car() { Id = 3, BrandId = suzuki.Id, RentPrice = 25000, Model = "Suzuki Vitara" };
            Car celerio = new Car() { Id = 4, BrandId = suzuki.Id, RentPrice = 15000, Model = "Suzuki Celerio" };
            Car s90 = new Car() { Id = 5, BrandId = volvo.Id, RentPrice = 80000, Model = "Volvo s90" };
            Car v60 = new Car() { Id = 6, BrandId = volvo.Id, RentPrice = 65000, Model = "volvo v60" };


            Rent sanya = new Rent() { Id = 1, Cost = 1* astra.RentPrice,CarId=astra.Id ,FirstName = "Kis", LastName = "Sándor", Mail = "kissanya@gmail.com", Phone = "+3680323523", RentTime = 1 };
            Rent bela = new Rent() { Id = 2, Cost = 2 * corsa.RentPrice,CarId=corsa.Id, FirstName = "Nagy", LastName = "Bela", Mail = "nagybela@gmail.com", Phone = "+36768246010", RentTime = 2 };
            Rent geza = new Rent() { Id = 3, Cost = 4 * vitara.RentPrice, CarId = vitara.Id, FirstName = "Kis", LastName = "Sándor", Mail = "kissanya@gmail.com", Phone = "+3612676212", RentTime = 4 };
            Rent jozska = new Rent() { Id =4, Cost = 10 * celerio.RentPrice, CarId = celerio.Id, FirstName = "Kis", LastName = "Sándor", Mail = "kissanya@gmail.com", Phone = "+36901233251", RentTime = 10 };
            Rent fonokne = new Rent() { Id = 5, Cost = 31 * v60.RentPrice, CarId = v60.Id, FirstName = "Fonokne", LastName = "Julcsi", Mail = "kissanya@gmail.com", Phone = "+3680898765", RentTime = 31 };
            Rent fonok = new Rent() { Id = 6, Cost = 60 * s90.RentPrice,  CarId = s90.Id, FirstName = "Fonok", LastName = "Ferenc", Mail = "kissanya@gmail.com", Phone = "+36994532171", RentTime = 60 };

            modelBuilder.Entity<Brand>().HasData(opel, suzuki, volvo);
            modelBuilder.Entity<Car>().HasData(astra, vitara, corsa, celerio, s90, v60);
            modelBuilder.Entity<Rent>().HasData(sanya, bela, geza, jozska, fonokne, fonok);
        }

    }
}
