using BL.Managers.Interfaces;
using System;
using Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;
using Model.Dto;
using AutoMapper;
using BL.Util;

namespace BL.Managers
{
    public class StudentManager : IStudentManager
    {
        private IStudentReporsitory _studentRepository;

        public StudentManager(IStudentReporsitory studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student Create(Student student)
        {
            if (!_studentRepository.Records.Any(x => x.Email == "test@test123.com"))
            {
                _studentRepository.Add(student);
            }
            else
            {
                return _studentRepository.Records.Where(x => x.Email == student.Email).FirstOrDefault();
            }

            return student;
        }

        public void DeleteById(int id)
        {
            var student = _studentRepository.GetById(id);
            _studentRepository.Delete(student);
        }

        public List<StudentDto> GetAll()
        {
            return Mapper.Map<List<Student>, List<StudentDto>>(_studentRepository.GetAll().ToList());
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public StudentDto GetByIdWithDetail(int id)
        {
            
            var studentDto = Mapper.Map<Student, StudentDto>(_studentRepository.GetById(id));
            var query = from c in _studentRepository.Context.Courses
                        join sc in _studentRepository.Context.StudentCourses on c.Id equals sc.CourseId
                        where sc.StudentId == id
                        select c;
            studentDto.Courses = Mapper.Map<List<Course>, List<CourseDto>>(query.ToList());
            return studentDto;
        }

        public StudentSearchDto SearchStudent(SearchAttribute search)
        {
            if (search.PageNumber == 0)
            {
                search.PageNumber = 1;
            }
            if (search.PageSize == 0)
            {
                search.PageSize = 10;
            }
            var students =_studentRepository.Records.Search(search.SearchValue);
            students = students.ApplySort(search.SortString, search.SortOrder);

            var SearchResult = new StudentSearchDto
            {
                PageSize = search.PageSize,
                TotalPage = students.Count() / search.PageSize + (students.Count() % search.PageSize == 0 ? 0 : 1)
            };

            SearchResult.PageNumber = search.PageNumber > SearchResult.TotalPage ? 1 : search.PageNumber;

            SearchResult.Students = Mapper.Map<List<Student>, List<StudentDto>>(students.Skip((SearchResult.PageNumber - 1) * SearchResult.PageSize).Take(SearchResult.PageSize).ToList());
            return SearchResult;
        }

        public void EnroleCourse(int studentId, int courseId)
        {
            var student = _studentRepository.GetById(studentId);
            student.Credit = student.Credit - 4;
            //TODO add StudentCourse record to tabel
            _studentRepository.Update(student);
        }

        public Student Update(Student record)
        {
            record = _studentRepository.Update(record);
            return record;
        }

        List<Student> IGenericManager<Student>.GetAll()
        {
            return _studentRepository.Records.ToList();
        }

        public void EnrollCourse(int studentId, int courseId)
        {
            if(!_studentRepository.Context.StudentCourses.Any(x => x.StudentId == studentId && x.CourseId == courseId))
            {
                _studentRepository.Context.StudentCourses.Add(new StudentCourse
                {
                    StudentId = studentId,
                    CourseId = courseId
                });
                _studentRepository.Context.SaveChanges();
            }
        }

        public void CancelCourse(int studentId, int courseId)
        {
            var studentCourse = _studentRepository.Context.StudentCourses.FirstOrDefault(x => x.StudentId == studentId && x.CourseId == courseId);
            if (studentCourse != null)
            {
                _studentRepository.Context.StudentCourses.Remove(studentCourse);
                _studentRepository.Context.SaveChanges();
            }
        }
    }
}
