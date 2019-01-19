using Data.Database;
using Data.Repositories.Interfaces;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentReporsitory 
    {
        public StudentRepository(LMSEntities context) : base(context)
        {
            
        }

        public LMSEntities Context => _context;
    }
}
