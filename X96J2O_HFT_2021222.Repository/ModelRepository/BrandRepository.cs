using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X96J2O_HFT_2021222.Models;
using X96J2O_HFT_2021222.Repository.Interfaces;

namespace X96J2O_HFT_2021222.Repository.Classes
{
    public class BrandRepository : Repository<Brand>, IRepository<Brand>
    {
        public BrandRepository(RentDbContext ctx) : base(ctx)
        {
        }

        public override Brand Read(int id)
        {
            return ctx.Brands.FirstOrDefault(t => t.brandId.Equals(id));
        }

        public override void Update(Brand item)
        {
            var old = Read(item.brandId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
