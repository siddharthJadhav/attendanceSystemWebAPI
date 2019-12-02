using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AttendanceSystemWebAPI.DAL;
using AttendanceSystemWebAPI.Models;

namespace AttendanceSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private mysqlContextDAL context { get; set; }

        public EmployeeController(mysqlContextDAL context)
        {
            this.context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            List<EmployeesModel> employeeList = new EmployeeDAL(context).GetAllEmployeeList();
            //return Ok(employeeList);
            return Ok(new { count = employeeList.Count, result = employeeList });
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            EmployeesModel employee = new EmployeeDAL(context).GetEmployeeDetail(id);
            return Ok(new { getEmployeeDetail = employee });
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] EmployeesModel employee)
        {
            EmployeesModel employeeDetail = new EmployeeDAL(context).AddEmployee(employee);
            return Ok( new { employeeDetail = employeeDetail } );
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeesModel employee)
        {
            EmployeesModel employeeDetail = new EmployeeDAL(context).UpdateEmployeeDetail(id, employee);
            return Ok( new { employeeDetail = employeeDetail });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int employeeID = new EmployeeDAL(context).DeleteEmployeeDetail(id);
            return Ok( new { ID = employeeID } );
        }
    }
}
