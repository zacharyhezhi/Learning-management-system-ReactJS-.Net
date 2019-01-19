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
    public class CoursesController : ApiController
    {
        private ICourseManager _courseManager;

        public CoursesController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        // GET: api/Course
        public IHttpActionResult Get()
        {
            return Ok(_courseManager.GetAll());
        }

        // GET: api/Course/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_courseManager.GetById(id));
        }

        // POST: api/Course
        public IHttpActionResult Post([FromBody]Course course)
        {
            course = _courseManager.Create(course);
            return Ok(course);
        }

        // PUT: api/Course/5
        public void Put([FromBody]Course course)
        {
            _courseManager.Update(course);
        }

        // DELETE: api/Course/5
        public void Delete(int id)
        {
            _courseManager.DeleteById(id);
        }
    }
}
