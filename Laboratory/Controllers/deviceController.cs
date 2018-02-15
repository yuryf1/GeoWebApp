using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Laboratory.Models;
using System.Threading.Tasks;

namespace Laboratory.Controllers
{
    public class deviceController : ApiController
    {
        //Location[] location = new Location[]
        //    {
        //    new Location { Id = 1, Name = "Tomato Soup" },
        //    new Location { Id = 2, Name = "Yo-yo"},
        //    new Location { Id = 3, Name = "Hammer" }
        //    };

        // GET: api/device
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/device/5
        public async Task<string> Get(string id)
        {
            await _Default.RecordAsync(id);
            return "Переданная строка записана";
        }


        // POST: api/device
        public void Post([FromBody]string value)
        {
           // _Default.Record(value);
        }

        // PUT: api/device/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/device/5
        public void Delete(int id)
        {
        }
    }
}
