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
    /// <summary>
    /// Designation End point
    /// </summary>
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        /// <summary>
        /// Get Action for dessignation list
        /// </summary>
        /// <returns>List of designations</returns>
        [HttpGet("Get")]
        public IActionResult Get()
        {
            try
            {
                List<Designation> designations = new DesignationEntry().Select();
                return Ok(designations);
            }
            catch (Exception ex)
            {
                Log.ErrorToFile(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}