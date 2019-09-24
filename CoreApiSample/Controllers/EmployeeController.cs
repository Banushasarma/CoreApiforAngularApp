using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using CoreApiSample.DL;
using CoreApiSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using CoreApiSample.Utility;

namespace CoreApiSample.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
        [HttpGet("GetEmployees")]
        public ActionResult GetEmployees()
        {
            try
            {
                List<Employee> emplList = new EmployeeEntry().GetEmployees();
                return Ok(emplList);
            }
            catch (Exception ex)
            {
                Log.ErrorToFile(ex.Message);
                return BadRequest(ex.Message);
            }
            
        } 
         
        [HttpGet("GetEmployees/{id}")]
        public ActionResult GetEmployees(int id)
        {
            try
            {
                Employee employee = new EmployeeEntry().GetEmployees().Where(X => X.Id == id).FirstOrDefault();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                Log.ErrorToFile(ex.Message);
                return BadRequest(ex.Message);
            } 
        }
    }
}