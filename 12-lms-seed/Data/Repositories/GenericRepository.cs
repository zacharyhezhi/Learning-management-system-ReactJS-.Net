using Data.Database;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public LMSEntities _context;
        public DbSet<T> Records
        {
            get { return _context.Set<T>(); }
        }

        public GenericRepository(LMSEntities context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return Records;
        }

        public virtual T GetById(int id)
        {
            return Records.Find(id);
        }

        public virtual T Add(T record)
        {
            Records.Add(record);
            _context.SaveChanges();
            return record;
        }

        public virtual void Delete(T record)
        {
            Records.Remove(record);
            _context.SaveChanges();
        }

        public T Update(T record)
        {
            Records.Attach(record);
            _context.Entry(record).State = EntityState.Modified;
            _context.SaveChanges();
            return record;
        }
    }
}
