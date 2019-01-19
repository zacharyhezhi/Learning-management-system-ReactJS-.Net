using Model.Dto;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
    public interface IStudentManager : IGenericManager<Student>
    {
        StudentDto GetByIdWithDetail(int id);
        new List<StudentDto> GetAll();
        StudentSearchDto SearchStudent(SearchAttribute search);
        void EnrollCourse(int studentId, int courseId);
        void CancelCourse(int studentId, int courseId);
    }
}
