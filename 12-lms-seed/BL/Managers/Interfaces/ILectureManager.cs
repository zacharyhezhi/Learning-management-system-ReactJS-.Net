using Model.Dto;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
    public interface ILecturerManager : IGenericManager<Lecturer>
    {
        void TeachCourse(int lecturerId, int courseId);
        void UnTeachCourse(int lecturerId, int courseId);
        LecturerDto GetDtoById(int lecturerId);
    }
}
