using System.Collections.Generic;
using System.Linq;
using X96J2O_HFT_2021222.Models;

namespace X96J2O_HFT_2021222.Logic
{
    public interface ICarLogic
    {
        double AVGRentPrice();
        IEnumerable<KeyValuePair<string, double>> AVGRentPriceByBrands();
        void Create(Car item);
        void Delete(int id);
        Car Read(int id);
        IQueryable<Car> ReadAll();
        void Update(Car item);
    }
}