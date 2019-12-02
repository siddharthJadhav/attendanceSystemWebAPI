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

        public EmployeesModel UpdateEmployeeDetail(int id, EmployeesModel emplyeeObj)
        {
            EmployeesModel employeeDetail = context.Employees.First<EmployeesModel>(employee => employee.ID == id);
            //employeeDetail = emplyeeObj;
            employeeDetail.FirstName = emplyeeObj.FirstName;
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

    }
}
