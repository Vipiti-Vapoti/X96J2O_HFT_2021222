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
            double price = rest.GetSingle<double>("Stat/AvgCarPrice");
            Console.WriteLine($"Averege car price = {price}");
            Console.ReadLine();
        }

        public void AvgRentPriceByBrand()
        {
            var items = rest.Get<KeyValuePair<string, double>>("Stat/AvgRentPriceByBrands");
            Console.WriteLine("Brand\tAvgPrice");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
            Console.ReadLine();
        }
        public void AvgGetAvarageInComePerCarModellPerYearCarRentPrice(int year)
        {
            var items = rest.Get<KeyValuePair<string, double>>("Stat/AvgRentPriceByBrands");
            Console.WriteLine("Car\tAvgIncome");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
            Console.ReadLine();
        }
        public void HastoPayFine()
        {
            var items = rest.Get<List<int>>("Stat/HasToPayRentFine");
            Console.WriteLine("ID'S:");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        public void StillOpenRentsByCarId()
        {
            var items = rest.Get<List<int>>("Stat/StillOpenRentsByCarId");
            Console.WriteLine("ID'S:");
            if (items != null)
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();

            }
            Console.WriteLine("There is no data in here...");
            Console.ReadLine();

        }

    }
}
