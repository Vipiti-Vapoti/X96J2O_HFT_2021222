using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X96J2O_HFT_2021222.Repository.Interfaces;
using X96J2O_HFT_2021222.Repository;
using X96J2O_HFT_2021222.Models;

namespace X96J2O_HFT_2021222.Logic
{
    public class CarLogic 
    {
        IRepository<Car> repo;

        public CarLogic(IRepository<Car> repo)
        {
            this.repo = repo;
        }

        public void Create(Car item)
        {
            if (item==null)
            {
                throw new ArgumentException("Invalid car!");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Car Read(int id)
        {
            var car = this.repo.Read(id);
            if (car != null)
            {
                return car;

            }
            else
            {
                throw new ArgumentException("car not exist!");
            }
            
        }

        public IQueryable<Car> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Car item)
        {
            this.repo.Update(item);
        }
        //NON CRUD-S
        public double AVGRentPrice()
        {
            return this.repo.ReadAll().Average(c => c.RentPrice);
        }

        public IEnumerable<KeyValuePair<string, double>> AVGRentPriceByBrands()
        {
            return from x in repo.ReadAll()
                   group x by x.Brand.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.RentPrice));
        }
    }
}
