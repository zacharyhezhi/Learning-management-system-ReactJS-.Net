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
    public class LectureRepository : GenericRepository<Lecturer>, ILecturerRepository
    {
        public LectureRepository(LMSEntities context) : base(context)
        {

        }
    }
}
