using System.Collections.Generic;
using System.Web.Http;

namespace SwaggerAPI.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]string value)
        {
            return Created("", value);
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return Created("", value);
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            return Content(System.Net.HttpStatusCode.OK, "Record with id = " + id + " deleted successfully.");
        }
    }
}
