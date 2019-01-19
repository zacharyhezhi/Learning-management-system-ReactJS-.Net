using BL.Managers.Interfaces;
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
    public class LecturersController : ApiController
    {
        private ILecturerManager _lectureManager;

        public LecturersController(ILecturerManager lectureManager)
        {
            _lectureManager = lectureManager;
        }
        // GET: api/Lecture
        public IHttpActionResult Get()
        {
            return Ok(_lectureManager.GetAll());
        }

        // GET: api/Lecture/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_lectureManager.GetDtoById(id));
        }

        // POST: api/Lecture
        public IHttpActionResult Post([FromBody]Lecturer lecture)
        {
            lecture = _lectureManager.Create(lecture);
            return Ok(lecture);
        }

        // PUT: api/Lecture/5
        public void Put([FromBody]Lecturer lecture)
        {
            _lectureManager.Update(lecture);
        }

        // DELETE: api/Lecture/5
        public void Delete(int id)
        {
            _lectureManager.DeleteById(id);
        }

        [HttpPost]
        [Route("api/lectures/teachcourse")]
        public IHttpActionResult EnrollCourse(int lecturerId, int courseId)
        {
            _lectureManager.TeachCourse(lecturerId, courseId);
            return Ok();
        }

        [HttpPost]
        [Route("api/lectures/unteachcourse")]
        public IHttpActionResult CancelCourse(int lecturerId, int courseId)
        {
            _lectureManager.UnTeachCourse(lecturerId, courseId);
            return Ok();
        }
    }
}
