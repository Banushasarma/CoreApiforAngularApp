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
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet("GetLogin")]
        public ActionResult Login(string UserName,string Password)
        {
            try
            {
                List<Login> retList = new LoginEntry().GetLogin(UserName, Password);
                if (retList.Count > 0)
                    return Ok("Success");
                else
                    return BadRequest("Invalid Login");
            }
            catch (Exception ex)
            {
                Log.ErrorToFile(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}