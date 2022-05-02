using System;
using X96J2O_HFT_2021222.Models;
using X96J2O_HFT_2021222.Repository.Interfaces;
using X96J2O_HFT_2021222.Repository;
using System.Linq;
using System.Collections.Generic;

namespace X96J2O_HFT_2021222.Logic
{
    public class RentLogic 
    {
        IRepository<Rent> repo;

        public RentLogic(IRepository<Rent> repo)
        {
            this.repo = repo;
        }

        public void Create(Rent item)
        {
            if (item.In != null && item.In?.Subtract(item.Out).TotalDays>0)
            {
                throw new ArgumentException("Invalid In time...");
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
            if (rent == null)
            {
                throw new ArgumentException("Rent not exist!");
            }
            return rent;
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
        public IEnumerable<KeyValuePair<string, double>> GetAvarageInComePerBrandPerYear(int year)
        {
            return from x in repo.ReadAll().Where(t=> t.In!=null && t.Out.Year.Equals(year))
                   group x by x.Car.Brand.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.Car.RentPrice));
        }
        public IEnumerable<int> HasToPayFine()
        {
            return this.repo.ReadAll().Where(t => t.In == null && DateTime.Now.Subtract(t.Out).TotalDays > 365).Select(t => t.Id).ToList();
        }
        public IEnumerable<int> StillOpenRentsById()
        {
            return repo.ReadAll().Where(t => t.In == null).Select(t => t.CarId).ToList();
        }

    }
}
