using System;
using Microsoft.AspNetCore.Mvc;
using ProjectX.BusinessLogic.Interfaces;
using ProjectX.Models.Models;

namespace HRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
        public IEmployeeBL _empBl;
        public EmployeeController(IEmployeeBL empBl)
        {
            _empBl = empBl;
        }

        /// <summary>
        /// Action returns the employee details you queried. when the application makes the call, the uri should look like this api/employee/get/e=4cbed9e0-8b05-4704-8f04-85035e21e576
        /// </summary>
        /// <param name="EmployeeId">the employee id</param>
        /// <returns></returns>
        [HttpGet("get/e={EmployeeId:Guid}")]
        public ActionResult<Employee> GetEmployeeDetails(Guid EmployeeId)
        {
            Employee employee = _empBl.GetEmployeeDetails(EmployeeId);
            return employee;
        }
    }
}