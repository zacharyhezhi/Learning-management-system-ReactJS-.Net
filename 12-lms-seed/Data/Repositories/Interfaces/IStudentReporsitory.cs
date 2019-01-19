using Data.Database;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IStudentReporsitory : IGenericRepository<Student>
    {
        LMSEntities Context { get; }
    }
}
