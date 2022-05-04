using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X96J2O_HFT_2021222.Client
{
    class NonCrudService
    {
        private RestService rest;

        public NonCrudService(RestService rest)
        {
            this.rest = rest;
        }

        public void AvgCarPrice()
        {
            double price = rest.GetSingle<double>("Stat/AvgCarRentPrice");
            Console.WriteLine($"Averege car price = {price}");
            Console.ReadLine();
        }

        public void AvgRentPriceByBrand()
        {
            var items = rest.Get<KeyValuePair<string, double>>("Stat/AvgPriceByBrands");
            Console.WriteLine("Brand\tAvgPrice");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
            Console.ReadLine();
        }
        public void AvgGetAvarageInComePerCarModellPerYearCarRentPrice()
        {
            Console.WriteLine("Enter a Year:");
            int year = int.Parse(Console.ReadLine());
            var items = rest.Getp<KeyValuePair<string, double>>(year,"Stat/GetAvarageInComePerCarModellPerYearCarRentPrice");
            Console.WriteLine("Car\tAvgIncome");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
            Console.ReadLine();
        }
        public void HastoPayFine()
        {
            var items = rest.Get<long>("Stat/HasToPayRentFine").ToList();

            if (items.Count != 0)
            {
                Console.WriteLine("ID'S:");
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();

            }
            else if (items.Count==0)
            {
                Console.WriteLine("There is no data in here...");
                Console.ReadLine();
            }
            
            
        }
        public void StillOpenRentsByCarId()
        {
            var items = rest.Get<long>("Stat/StillOpenRentsByCarId").ToList();
            if (items != null)
            {
                Console.WriteLine("ID'S:");
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();

            }
            else if (items.Count == 0)
            {
                Console.WriteLine("There is no data in here...");
                Console.ReadLine();
            }
            

        }

    }
}
