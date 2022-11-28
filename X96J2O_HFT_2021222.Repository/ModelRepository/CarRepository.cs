using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X96J2O_HFT_2021222.Models;
using X96J2O_HFT_2021222.Repository.Interfaces;

namespace X96J2O_HFT_2021222.Repository.Classes
{
    public class CarRepository : Repository<Car>, IRepository<Car>
    {
        public CarRepository(RentDbContext ctx) : base(ctx)
        {
        }

        public override Car Read(int id)
        {
            return ctx.Cars.FirstOrDefault(car => car.carId == id);
        }

        public override void Update(Car item)
        {
            var old = Read(item.carId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
