using MvcApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcApplication.Models;
using Newtonsoft.Json;
using Ninject;

namespace MvcApplication.Controllers
{
    public class RestController : ApiController
    {
        [Inject]
        IMemoryDatabase Database { get; set; }


        // GET: api/Rest
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Rest/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rest
        public string Post([FromBody]inputDataForm[] value)
        {
            //inputDataForm[]  values = JsonConvert.DeserializeObject<inputDataForm[]>(value);
            return "ok";
        }

        // PUT: api/Rest/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rest/5
        public void Delete(int id)
        {
        }
    }
}
