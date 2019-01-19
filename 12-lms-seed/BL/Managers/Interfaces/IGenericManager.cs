using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
    public interface IGenericManager<T> where T : class
    {
        T Create(T record);
        T Update(T record);
        T GetById(int id);
        List<T> GetAll();
        void DeleteById(int id);
    }
}
