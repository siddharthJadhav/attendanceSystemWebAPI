using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceSystemWebAPI.Models
{
	public class EmployeesModel
	{
		public int ID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        public int Salary { get; set; }

		//public string Designation { get; set; }

        //public string Shift { get; set; }

        //public string Address { get; set; }

        //public string Email { get; set; }

        //[Column(TypeName = "Date")]
        //public DateTime DOB { get; set; }

        //public DateTime JoiningDate { get; set; }
    }
}
