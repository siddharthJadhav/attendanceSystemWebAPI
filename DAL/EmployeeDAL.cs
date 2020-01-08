using System;
using System.Collections.Generic;
using System.Linq;
using AttendanceSystemWebAPI.Models;

namespace AttendanceSystemWebAPI.DAL
{
    public class EmployeeDAL
    {
        private mysqlContextDAL context { get; set; }

        public EmployeeDAL(mysqlContextDAL context)
        {
            this.context = context;
        }

        public List<EmployeesModel> GetAllEmployeeList()
        {
            return context.Employees.ToList<EmployeesModel>();
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

    }
}
