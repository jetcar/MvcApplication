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
        public readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IDatabase Database { get; set; }

        public RestController(IDatabase database)
        {
            Database = database;
        }

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
        public string Post([FromBody]inputDataForm value)
        {
            logger.DebugFormat("input data: {0}",value.ToString());

            Database.AddParkingInfo(value.clientId, value.startdate, value.enddate);
            return "ok";
        }

        // PUT: api/Rest/5
        public void Put(int id, [FromBody]inputDataForm[] value)
        {
        }

        // DELETE: api/Rest/5
        public void Delete(int id)
        {
        }
    }
}
