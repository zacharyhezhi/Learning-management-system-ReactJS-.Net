using BL.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LMS.Controllers
{

    public class ValuesController : ApiController
    {
        // GET api/values
        [Route("api/values/getnoasync")]
        public long Get()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ContentManager service = new ContentManager();
            var item1 = service.GetItem1();
            var item2 = service.GetItem2();
            var item3 = service.GetItem3();
            
            return watch.ElapsedMilliseconds;
        }

        [Route("api/values/getasync")]
        public async Task<IHttpActionResult> GetAsync()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            AsyncContentManager service = new AsyncContentManager();
            var item1Task = service.GetItem1Async();
            var item2Task = service.GetItem2Async();
            var item3Task = service.GetItem3Async();

            var item1 = await item1Task;
            var item2 = await item2Task;
            var item3 = await item3Task;
            return Ok(watch.ElapsedMilliseconds);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
