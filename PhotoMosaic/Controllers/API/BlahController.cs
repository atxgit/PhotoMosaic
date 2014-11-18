using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhotoMosaic.Controllers.APIs
{
    public class BlahController : ApiController
    {
        // GET api/blah
        public IEnumerable<string> Get()
        {
            return new string[] { "blah", "blah blah" };
        }

        // GET api/blah/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/blah
        public void Post([FromBody]string value)
        {
        }

        // PUT api/blah/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/blah/5
        public void Delete(int id)
        {
        }
    }
}
