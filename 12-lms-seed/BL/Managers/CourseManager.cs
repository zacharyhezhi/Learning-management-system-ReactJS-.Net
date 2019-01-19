using BL.Managers.Interfaces;
using Data.Repositories.Interfaces;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
    public class CourseManager : ICourseManager
    {
        private ICourseRepository _courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public Course Create(Course record)
        {
            record = _courseRepository.Add(record);
            return record;
        }

        public void DeleteById(int id)
        {
            var course = _courseRepository.GetById(id);
            _courseRepository.Delete(course);
        }

        public List<Course> GetAll()
        {
            return _courseRepository.Records.ToList();
        }

        public Course GetById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public Course Update(Course record)
        {
            record = _courseRepository.Update(record);
            return record;
        }
    }
}
