using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X96J2O_HFT_2021222.Models;
using X96J2O_HFT_2021222.Repository.Interfaces;

namespace X96J2O_HFT_2021222.Repository.Classes
{
    public class RentRepository : Repository<Rent>,IRepository<Rent> {
        public RentRepository(RentDbContext ctx) : base(ctx)
        {
        }

        public override Rent Read(int id)
        {
            return ctx.Rents.FirstOrDefault(t=>t.rentId ==id);
        }

        public override void Update(Rent item)
        {
            var old = Read(item.rentId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
