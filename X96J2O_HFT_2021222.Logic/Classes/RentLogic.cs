using System;
using X96J2O_HFT_2021222.Models;
using X96J2O_HFT_2021222.Repository.Interfaces;
using X96J2O_HFT_2021222.Repository;
using System.Linq;
using System.Collections.Generic;

namespace X96J2O_HFT_2021222.Logic
{
    public class RentLogic : IRentLogic
    {
        IRepository<Rent> repo;

        public RentLogic(IRepository<Rent> repo)
        {
            this.repo = repo;
        }

        public void Create(Rent item)
        {
            if ((item.LastName == null || item.FirstName == null) || (item.FirstName == null && item.LastName == null))
            {
                throw new ArgumentException("Please fill name...");
            }
            if (item.In != null && DateTime.Parse(item.In) <= DateTime.Parse(item.Out))
            {
                throw new ArgumentException("Invalid Rent time...");
            }

            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Rent Read(int id)
        {
            var rent = this.repo.Read(id);
            if (rent != null)
            {
                return rent;
                
            }
            throw new ArgumentException("Rent not exist!");
        }

        public IQueryable<Rent> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Rent item)
        {
            this.repo.Update(item);
        }
        //Non CRUD-S
        public IEnumerable<KeyValuePair<string, double>> GetAvarageInComePerCarModellPerYear(int year)
        {
            return from x in repo.ReadAll().Where(t => DateTime.Parse(t.Out).Year.Equals(year)).ToList()
                   group x by x.Car.Model into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.In != null ? (t.Car.RentPrice * (DateTime.Parse(t.In).Subtract(DateTime.Parse(t.Out)).TotalDays)) : t.Car.RentPrice * 0));

        }
        public IEnumerable<int> HasToPayFine()
        {
            return this.repo.ReadAll().Where(t => t.In == null && DateTime.Now.Subtract(DateTime.Parse(t.Out)).TotalDays > 365).Select(t => t.rentId).ToList();
        }
        public IEnumerable<int> StillOpenRentsByCarId()
        {
            return repo.ReadAll().Where(t => t.In == null).Select(t => t.CarId).ToList();
        }

    }
}
