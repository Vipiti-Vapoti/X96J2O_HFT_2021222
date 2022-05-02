using System;
using System.Linq;
using X96J2O_HFT_2021222.Repository;

namespace X96J2O_HFT_2021222.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            RentDbContext ctx = new RentDbContext();
           ctx.Cars.ToList().ForEach(t => Console.WriteLine(t.Model));
           ctx.Brands.ToList().ForEach(t => Console.WriteLine(t.Name));
           ctx.Rents.ToList().ForEach(t => Console.WriteLine(t.FirstName));
        }
    }
}
