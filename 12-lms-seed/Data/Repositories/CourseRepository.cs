using Data.Database;
using Data.Repositories.Interfaces;
using Model.Model;

namespace Data.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(LMSEntities context) : base(context)
        {

        }
    }
}
