using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X96J2O_HFT_2021222.Repository.Interfaces;

namespace X96J2O_HFT_2021222.Repository.Classes
{
    public abstract class Repository <T>:IReporitory<T> where T : class
    {
        protected RentDbContext ctx;
        public Repository(RentDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
          ctx.Set<T>().Remove(Read(id));
          ctx.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        abstract public void Update(T item);
        abstract public T Read(int id);

    }
}
