using System.Collections.Generic;
using System.Linq;
using X96J2O_HFT_2021222.Models;

namespace X96J2O_HFT_2021222.Logic
{
    public interface IRentLogic
    {
        void Create(Rent item);
        void Delete(int id);
        IEnumerable<KeyValuePair<string, double>> GetAvarageInComePerCarModellPerYear(int year);
        IEnumerable<int> HasToPayFine();
        Rent Read(int id);
        IQueryable<Rent> ReadAll();
        IEnumerable<int> StillOpenRentsByCarId();
        void Update(Rent item);
    }
}