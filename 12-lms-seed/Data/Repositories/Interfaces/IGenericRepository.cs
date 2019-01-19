using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        DbSet<T> Records { get; }
        IEnumerable<T> GetAll();
        T GetById(int Id);
        T Add(T record);
        T Update(T record);
        void Delete(T record);
    }
}
