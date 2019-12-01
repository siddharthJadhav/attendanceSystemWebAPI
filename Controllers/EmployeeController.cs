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
            return context.Employees.ToList<EmployeesModel>();
        }

        public EmployeesModel getEmployeeDetail(int id)
        {
            return context.Employees.First(employee => employee.ID == id);
        }

        public EmployeesModel addEmployee(EmployeesModel employeeObj)
        {
            EmployeesModel employee = new EmployeesModel
                {
                FirstName = "Siddharth",
                LastName = "Jadhav",
                Gender = "Male",
                Salary = 10000
                };
            context.Employees.Add(employee);
            return employee;
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
        public IActionResult Get(int id)
        {
            EmployeesModel employee = getEmployeeDetail(id);
            return Ok(new { getEmployeeDetail = employee });
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] EmployeesModel employee)
        {
            EmployeesModel employeeDetail = addEmployee(employee);
            return Ok( new { employeeDetail = employeeDetail } );
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
