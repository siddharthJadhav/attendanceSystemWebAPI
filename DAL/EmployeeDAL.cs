using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSystemWebAPI.Models;
using MySql.Data.MySqlClient;

namespace AttendanceSystemWebAPI.DAL
{
    public class EmployeeDAL
    {
        private mysqlContextDAL context { get; set; }

        public EmployeeDAL(mysqlContextDAL context)
        {
            this.context = context;
        }

        public List<EmployeesModel> GetAllEmployeeList(string FirstName, string LastName, string Gender, string salary, string SalrySort)
        {
            return context.Employees.Where((EmployeesModel employee) => (FirstName == null || employee.FirstName.ToLower().Contains(FirstName.ToLower())) && (LastName == null || employee.LastName.ToLower().Contains(LastName.ToLower())) && (Gender == null || Gender == employee.Gender)).ToList<EmployeesModel>();
        }

        public EmployeesModel GetEmployeeDetail(int id)
        {
            return context.Employees.First<EmployeesModel>(employee => employee.ID == id);
        }

        public EmployeesModel AddEmployee(EmployeesModel employeeObj)
        {
            EmployeesModel employee = new EmployeesModel
            {
                FirstName = employeeObj.FirstName,
                LastName = employeeObj.LastName,
                Gender = employeeObj.Gender,
                Salary = employeeObj.Salary
            };
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public EmployeesModel UpdateEmployeeDetail(EmployeesModel emplyeeObj)
        {
            EmployeesModel employeeDetail = context.Employees.First<EmployeesModel>(employee => employee.ID == emplyeeObj.ID);
            //employeeDetail = new EmployeesModel
            //{
            //    ID = emplyeeObj.ID,
            //    FirstName = emplyeeObj.FirstName,
            //    LastName = emplyeeObj.LastName,
            //    Gender = emplyeeObj.Gender,
            //    Salary = emplyeeObj.Salary
            //};

            employeeDetail.ID = emplyeeObj.ID;
            employeeDetail.FirstName = emplyeeObj.FirstName;
            employeeDetail.LastName = emplyeeObj.LastName;
            employeeDetail.Gender = emplyeeObj.Gender;
            employeeDetail.Salary = emplyeeObj.Salary;

            context.SaveChanges();
            return employeeDetail;
        }

        public int DeleteEmployeeDetail(int id)
        {
            EmployeesModel employeeDetail = context.Employees.First<EmployeesModel>(employee => employee.ID == id);
            context.Employees.Remove(employeeDetail);
            context.SaveChanges();
            return id;
        }

        public ErrorResponseModel EmployeeValidation(EmployeesModel req)
        {
            ErrorResponseModel error = null;

            if (req.ID <= 0)
            {
                error = new ErrorResponseModel(400, "Please provide Employee ID.");
            }
            return error;
        }

        public async Task<EmployeesModel> getEmployeeDetailUsingSP(int employeeID)
        {
            EmployeesModel emp = new EmployeesModel();
            //using (DbConnection cnn = DBContextFactory.GetWerqDBConnection())

            using (DbConnection cnn = new MySqlConnection("server=localhost;userid=root;pwd=rootroot;port=3306;database=EmployeeDB;sslmode=none;"))
            {
                DbCommand cmd = cnn.CreateDbCMD(CommandType.StoredProcedure, "sp_get_employee_details");
                cmd.AddCMDParam("employeeId", employeeID);
                await cnn.OpenAsync();
                using (DbDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        emp.ID = Convert.ToInt32(reader["ID"]);
                        emp.FirstName = reader["FirstName"].ToString();
                        emp.LastName = reader["LastName"].ToString();
                        emp.Gender = reader["Gender"].ToString();
                        emp.Salary = Convert.ToInt32(reader["Salary"]);

                    }
                }
                cnn.Close();
            }
            return emp;
        }

    }
}
