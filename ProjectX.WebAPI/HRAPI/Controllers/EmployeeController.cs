using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public ActionResult<Employee> GetEmployeeDetails(Guid EmployeeId)
        {
            Employee employee = _empBl.GetEmployeeDetails(EmployeeId);
            return employee;
        }
    }
}