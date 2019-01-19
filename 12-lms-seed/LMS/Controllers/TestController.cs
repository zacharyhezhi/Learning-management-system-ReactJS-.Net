using BL.Managers.Interfaces;
using Data.Database;
using Model.Dto;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LMS.Controllers
{
    [Authorize]
    public class TestController : ApiController
    {
        private readonly IUserManager _userManager;
        private readonly IStudentManager _studentManager;

        public TestController(IUserManager userManager, IStudentManager studentManager)
        {
            _userManager = userManager;
            _studentManager = studentManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/test/createuser")]
        public async Task<IHttpActionResult> Post(UserRegisterDto user)
        {
            var userDisplay = await _userManager.CreateUser(user);
            return Ok(userDisplay);
        }

        [HttpGet]
        [Route("api/test")]
        public IHttpActionResult Test()
        {
            using (LMSEntities context = new LMSEntities())
            {
                var students = context.Students.ToList();
                return Ok(students);
            }
        }
    }
}
