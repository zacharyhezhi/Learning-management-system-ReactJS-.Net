using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Email { get; set; }
        public Nullable<decimal> Credit { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
