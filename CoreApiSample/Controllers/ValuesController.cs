using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiSample.DL;
using CoreApiSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiSample.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet("GetEmployee")] 
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return new DBConnectivity().ExecuteSelectSP<Employee>("Employee_M_Select");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
