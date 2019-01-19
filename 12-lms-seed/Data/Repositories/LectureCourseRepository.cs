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
    public class LectureCourseRepository : GenericRepository<LecturerCourse>, ILecturerCourseRepository
    {
        public LectureCourseRepository(LMSEntities context) : base(context)
        {

        }
    }
}
