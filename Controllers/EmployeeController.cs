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
    [ExceptionFilter]
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
        public async Task<IActionResult> Get(string FirstName, string LastName, string Gender, string salary, string SalrySort)
        {
            //List<EmployeesModel> employeeList = new EmployeeDAL(context).GetAllEmployeeList(FirstName, LastName, Gender, salary, SalrySort);
            //return Ok(employeeList);

            List<EmployeesModel> employeeList = await new EmployeeDAL(context).getEmployeeListUsingSp();
            return Ok(new { count = employeeList.Count, result = employeeList });
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            //EmployeesModel employee = new EmployeeDAL(context).GetEmployeeDetail(id);

            EmployeesModel employee = await new EmployeeDAL(context).getEmployeeDetailUsingSP(id);
            if (employee.ID == 0) {
                return BadRequest(new ErrorResponseModel(400, "Employee does not exist!"));
            }
            else
            {
                return Ok(new { getEmployeeDetail = employee });
            }
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] EmployeesModel employee)
        {
            if(ModelState.IsValid)
            {
                EmployeesModel employeeDetail = new EmployeeDAL(context).AddEmployee(employee);
                return Ok(new { employeeDetail = employeeDetail });
            } else
            {
                return BadRequest(new ErrorResponseModel(400, ModelState));
            }
                
        }

        // PUT: api/Employee
        [HttpPut]
        public IActionResult Put([FromBody] EmployeesModel employee)
        {
            if (ModelState.IsValid)
            {
                ErrorResponseModel error = new EmployeeDAL(context).EmployeeValidation(employee);
                if (error != null)
                {
                    return BadRequest(error);
                }

                EmployeesModel employeeDetail = new EmployeeDAL(context).UpdateEmployeeDetail(employee);
                return Ok(new { employeeDetail = employeeDetail });
            } else
            {
                return BadRequest(new ErrorResponseModel(400, ModelState));
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int employeeID = new EmployeeDAL(context).DeleteEmployeeDetail(id);
            return Ok( new { ID = employeeID  } );
        }
    }
}
