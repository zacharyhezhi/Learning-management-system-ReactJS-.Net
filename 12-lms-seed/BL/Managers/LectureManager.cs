using AutoMapper;
using BL.Managers.Interfaces;
using Data.Repositories.Interfaces;
using Model.Dto;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
    public class LecturerManager : ILecturerManager
    {
        private ILecturerRepository _lectureRepository;
        private ILecturerCourseRepository _lecturerCourseRepository;
        private ICourseRepository _courseRepository;

        public LecturerManager(ILecturerRepository lecturerRepository, ILecturerCourseRepository lecturerCourseRepository, ICourseRepository courseRepository)
        {
            _lectureRepository = lecturerRepository;
            _lecturerCourseRepository = lecturerCourseRepository;
            _courseRepository = courseRepository;
        }
        public Lecturer Create(Lecturer record)
        {
            record = _lectureRepository.Add(record);
            return record;
        }

        public void DeleteById(int id)
        {
            var course = _lectureRepository.GetById(id);
            _lectureRepository.Delete(course);
        }

        public List<Lecturer> GetAll()
        {
            return _lectureRepository.Records.ToList();
        }

        public Lecturer GetById(int id)
        {
            return _lectureRepository.GetById(id);
        }

        public LecturerDto GetDtoById(int id)
        {
            var lecturer = _lectureRepository.GetById(id);
            var lecturerDto = Mapper.Map<Lecturer, LecturerDto>(lecturer);
            var courses = (from c in _courseRepository.Records
                                  join lc in _lecturerCourseRepository.Records on c.Id equals lc.CourseId
                                  join l in _lectureRepository.Records on lc.LecturerId equals l.Id
                                  where l.Id == id
                                  select c).ToList();
            lecturerDto.Courses = Mapper.Map<List<Course>, List<CourseDto>>(courses);
            return lecturerDto;
        }

        public void TeachCourse(int lecturerId, int courseId)
        {
            if (!_lecturerCourseRepository.Records.Any(x => x.LecturerId == lecturerId && x.CourseId == courseId))
            {
                _lecturerCourseRepository.Add(new LecturerCourse
                {
                    LecturerId = lecturerId,
                    CourseId = courseId
                });
            }
        }

        public void UnTeachCourse(int lecturerId, int courseId)
        {
            var lectureCourse = _lecturerCourseRepository.Records.FirstOrDefault(x => x.LecturerId == lecturerId && x.CourseId == courseId);

            if (lectureCourse != null)
            {
                _lecturerCourseRepository.Delete(lectureCourse);
            }
        }

        public Lecturer Update(Lecturer record)
        {
            record = _lectureRepository.Update(record);
            return record;
        }
    }
}
