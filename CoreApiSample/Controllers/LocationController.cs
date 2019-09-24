using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiSample.DL;
using CoreApiSample.Models;
using CoreApiSample.Utility;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiSample.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        [HttpGet("Get")]
        public IActionResult Get()
        {
            try
            {
                List<Location> locations = new LocationEntry().Select();
                return Ok(locations);
            }
            catch (Exception ex)
            {
                Log.ErrorToFile(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}