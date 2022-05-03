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
    public class BrandLogic : IBrandLogic
    {
        IRepository<Brand> repo;

        public BrandLogic(IRepository<Brand> repo)
        {
            this.repo = repo;
        }

        public void Create(Brand item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Brand Read(int id)
        {
            var brand = this.repo.Read(id);
            if (brand != null)
            {
                return brand;

            }
            else
            {
                throw new ArgumentException("car not exist!");
            }
        }

        public IQueryable<Brand> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Brand item)
        {
            this.repo.Update(item);
        }
    }
}
