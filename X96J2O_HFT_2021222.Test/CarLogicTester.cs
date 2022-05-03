using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X96J2O_HFT_2021222.Logic;
using X96J2O_HFT_2021222.Models;
using X96J2O_HFT_2021222.Repository.Interfaces;

namespace X96J2O_HFT_2021222.Test
{
    [TestFixture]
    public class CarLogicTester
    {
        CarLogic carLogic;
        [SetUp]
        public void Init()
        {
            var mockRepository = new Mock<IRepository<Car>>();
            List<Rent>fakerents=new List<Rent>();
            Brand fakeBrand = new Brand();
            fakeBrand.brandId = 1;
            fakeBrand.Name = "Opel";
            var cars = new List<Car>()
            {
                new Car() { carId = 1, BrandId = 1, RentPrice = 10000, Model = "Opel Astra G", Brand=fakeBrand, Rents=fakerents},
                new Car() { carId = 2, BrandId = 1, RentPrice = 10000, Model = "Opel Fronterra", Brand=fakeBrand, Rents=fakerents}

            }.AsQueryable();

            mockRepository.Setup(t => t.ReadAll())
                .Returns(cars);

            carLogic = new CarLogic(mockRepository.Object);
        }
        [Test]
        public void AVGPriceTest()
        {
            var result = carLogic.AVGRentPrice();

            Assert.That(result, Is.EqualTo(10000));
        }
        [Test]
        public void AVGRentPriceByBrands()
        {
            List<KeyValuePair<string, double>> expexted = new List<KeyValuePair<string, double>>()
            {
                  (new KeyValuePair<string, double>("Opel", 10000)),
            };
            
            var result= carLogic.AVGRentPriceByBrands();
            CollectionAssert.AreEqual(expexted, result);
        }
        [Test]
        public void ValidCreate()
        {
            Car tesztcar = new Car() {carId=3,BrandId=1, Model="Corsa-e", RentPrice=23000};
            try
            {
                carLogic.Create(tesztcar);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {

                Assert.IsTrue(false);
            }


        }
        [Test]
        public void InValidCreate()
        {
            Car tesztcar = null;
            try
            {
                carLogic.Create(tesztcar);
                Assert.IsTrue(false);
            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex.Message == "Invalid car!");
            }
        }
       [Test]
        public void InValidCarRead()
        {
            int id = 3;
            try
            {
                carLogic.Read(id);
                Assert.IsTrue(false);
            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex.Message == "car not exist!");
            }
        }
    }
}
