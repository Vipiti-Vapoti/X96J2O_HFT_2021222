using System.Collections.Generic;
using System.Linq;
using X96J2O_HFT_2021222.Models;

namespace X96J2O_HFT_2021222.Logic
{
    public interface IRentLogic
    {
        void Create(Rent item);
        void Delete(int id);
        double? GetAvarageInComePerYear(int year);
        List<int> HasToPayFine();
        Rent Read(int id);
        IQueryable<Rent> ReadAll();
        List<int> StillOpenRentsById();
        void Update(Rent item);
    }
}