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

        public List<EmployeesModel> getAllEmployeeList()
        {
            EmployeesModel employee = new EmployeesModel();
            return context.Employees.ToList<EmployeesModel>();
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            List<EmployeesModel> employeeList = getAllEmployeeList();
            //return Ok(employeeList);
            return Ok(new { count = employeeList.Count, result = employeeList });
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
