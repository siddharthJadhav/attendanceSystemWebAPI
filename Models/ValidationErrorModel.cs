using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystemWebAPI.Models
{
    public class ValidationErrorModel
    {
        public string Field { get; }
        public string Message { get; }
        public ValidationErrorModel(string field, string message)
        {
            Field = !string.IsNullOrEmpty(field) ? field : null;
            Message = message;
        }
    }
}
