using BL;
using BL.Managers.Interfaces;
using LMS.Filters;
using Model.Dto;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMS.Controllers
{
    [Authorize]
    public class StudentsController : ApiController
    {
        private IStudentManager _studentManager;

        public StudentsController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }
        // GET: api/Student
        public IHttpActionResult Get(string sortString = "id", string sortOrder = "asc", string searchValue = "", int pageSize = 10, int pageNumber = 1)
        {
            SearchAttribute search = new SearchAttribute()
            {
                SearchValue = searchValue,
                SortOrder = sortOrder,
                SortString = sortString,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            StudentSearchDto students = _studentManager.SearchStudent(search);

            return Ok(students);
        }

        //[Route("api/searchstudent/{sortString}/{sortOrder}/{searchValue}/{pageSize}/{pageNumber}")]
        //public IHttpActionResult SearchStudent(string sortString = "id", string sortOrder = "asc", string searchValue = "", int pageSize = 10, int pageNumber = 1)
        //{
        //    SearchAttribute search = new SearchAttribute()
        //    {
        //        SearchValue = searchValue,
        //        SortOrder = sortOrder,
        //        SortString = sortString,
        //        PageNumber = pageNumber,
        //        PageSize = pageSize
        //    };
        //    StudentSearchDto students = _studentManager.SearchStudent(search);

        //    return Ok(students);
        //}

        // GET: api/Student/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_studentManager.GetByIdWithDetail(id));
        }

        // POST: api/Student
        [HttpPost]
        public IHttpActionResult Post([FromBody]Student student)
        {
            student = _studentManager.Create(student);
            return Ok(student);
        }

        // PUT: api/Student/5
        [HttpPut]
        public void Put([FromBody]Student student)
        {
            _studentManager.Update(student);
        }

        // DELETE: api/Student/5
        public IHttpActionResult Delete(int id)
        {
            _studentManager.DeleteById(id);
            return Ok();
        }

        [HttpPost]
        [Route("api/students/enrollcourse")]
        public IHttpActionResult EnrollCourse(int studentId, int courseId)
        {
            _studentManager.EnrollCourse(studentId, courseId);
            return Ok();
        }

        [HttpPost]
        [Route("api/students/cancelcourse")]
        public IHttpActionResult CancelCourse(int studentId, int courseId)
        {
            _studentManager.CancelCourse(studentId, courseId);
            return Ok();
        }
    }
}
