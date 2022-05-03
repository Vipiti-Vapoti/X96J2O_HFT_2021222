using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using X96J2O_HFT_2021222.Logic;
using X96J2O_HFT_2021222.Models;
using X96J2O_HFT_2021222.Repository.Interfaces;

namespace X96J2O_HFT_2021222.Test
{

    [TestFixture]
    public class RentLogicTester
    {

        Mock<IRepository<Rent>> mockRepository;
        RentLogic rentlogic;
        [SetUp]
        public void Init()
        {
            mockRepository = new Mock<IRepository<Rent>>();

            Car fakeCar = new Car();
            fakeCar.carId = 1;
            fakeCar.Model = "Astra G";
            fakeCar.RentPrice = 1000;
            Car fakeCar2 = new Car();
            fakeCar2.carId = 2;
            fakeCar2.Model = "Vitara";
            fakeCar2.RentPrice = 2000;
            Car fakeCar3 = new Car();
            fakeCar3.carId = 3;
            fakeCar3.Model = "celerio";
            fakeCar3.RentPrice = 3000;
            Car fakeCar4 = new Car();
            fakeCar4.carId = 4;
            fakeCar4.Model = "Corsa D";
            fakeCar4.RentPrice = 4000;
            Car fakeCar5 = new Car();
            fakeCar5.carId = 5;
            fakeCar5.Model = "v60";
            fakeCar5.RentPrice = 5000;
            Car fakeCar6 = new Car();
            fakeCar6.carId = 6;
            fakeCar6.Model = "S90";
            fakeCar6.RentPrice = 6000;
            var rents = new List<Rent>()
            {
             new Rent() { rentId = 1,CarId=fakeCar.carId ,FirstName = "Kis", LastName = "Sándor", Mail = "kissanya@gmail.com", Phone = "+3680323523",Out="2022.04.13", In="2021.04.20", Car = fakeCar},
             new Rent() { rentId = 2, CarId = fakeCar.carId, FirstName = "Nagy", LastName = "Bela", Mail = "nagybela@gmail.com", Phone = "+36768246010", Out = "2022.05.13", In = "2021.05.23",Car = fakeCar },
             new Rent() { rentId = 3, CarId = fakeCar3.carId, FirstName = "Kis", LastName = "Laca", Mail = "kissanya@gmail.com", Phone = "+3612676212", Out = "2022.04.15", In = "2022.05.26", Car = fakeCar3},
             new Rent() { rentId = 4, CarId = fakeCar4.carId, FirstName = "Bauer", LastName = "Sándor", Mail = "kissanya@gmail.com", Phone = "+36901233251", Out = "2022.04.12", In = "2022.04.20", Car = fakeCar3 },
             new Rent() { rentId = 5, CarId = fakeCar5.carId, FirstName = "Fonokne", LastName = "Julcsi", Mail = "kissanya@gmail.com", Phone = "+3680898765", Out = "2021.04.13", In = "2021.04.22", Car = fakeCar4},
             new Rent() { rentId = 6, CarId = fakeCar6.carId, FirstName = "Fonok", LastName = "Ferenc", Mail = "kissanya@gmail.com", Phone = "+36994532171", Out = "2021.01.01", In =null, Car = fakeCar5 },

            }.AsQueryable();

            mockRepository.Setup(t => t.ReadAll())
                .Returns(rents);

            rentlogic = new RentLogic(mockRepository.Object);
        }

        [Test] 
        public void HasToPayFine()
        {
            var result = rentlogic.HasToPayFine().Single();
            Assert.That(result, Is.EqualTo(6));
        }
        [Test]
        public void StillOpenRentsById()
        {
            var result = rentlogic.StillOpenRentsByCarId().Single();
            Assert.That(result, Is.EqualTo(6));
        }
        [Test]
        public void GetAvarageInComePerCarModellPerYear()
        {
            List<KeyValuePair<string, double>> expexted = new List<KeyValuePair<string, double>>()
           {
               (new KeyValuePair<string, double>("Corsa D", 36000)),
               (new KeyValuePair<string, double>("v60", 0.0))
           };
            var result = rentlogic.GetAvarageInComePerCarModellPerYear(2021);
            CollectionAssert.AreEqual(expexted, result);
        }
        [Test]
        public void ValidCreate()
        {
            Rent tesztrent = new Rent() { rentId = 7, CarId = 1, FirstName = "Teszt", LastName = "Elek", Mail = "tesztelek@gmail.com", Phone = "+368023323", Out = "2021.04.13", In = "2021.04.20" };
            try
            {
                rentlogic.Create(tesztrent);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {

                Assert.IsTrue(false);
            }
            
           
        }
        [Test]
        public void InValidCreateDateBigger()
        {
            Rent tesztrent = new Rent() { rentId = 7, CarId = 1, FirstName = "Teszt", LastName = "Elek", Mail = "tesztelek@gmail.com", Phone = "+368023323", Out = "2022.04.13", In = "2021.04.20" };
            try
            {
                rentlogic.Create(tesztrent);
                Assert.IsTrue(false);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Invalid Rent time...");
            }
        }
        [Test]
        public void InValidNameCreate()
        {
            Rent tesztrent = new Rent() { rentId = 8, CarId = 1, FirstName = null, LastName = null, Mail = "tesztelek@gmail.com", Phone = "+368023323", Out = "2022.04.13", In = "2021.04.20" };
            try
            {
                rentlogic.Create(tesztrent);
                Assert.IsTrue(false);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Please fill name...");
            }
        }
        [Test]
        public void InValidRentRead()
        {
            int id = 7;
            try
            {
                rentlogic.Read(id);
                Assert.IsTrue(false);
            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex.Message == "Rent not exist!");
            }
        }
    }
}
