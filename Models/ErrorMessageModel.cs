using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystemWebAPI.Models
{
    public class ErrorMessageModel
    {

        public int Status { get; set; }
        public string Message { get; set; }
        public Exception ExceptionDetails { get; set; }
        public List<ValidationErrorModel> PendingDetails { get; }

        public ErrorMessageModel()
        {

        }
        public ErrorMessageModel(int status, string message)
        {
            this.Status = status;
            this.Message = message;
        }

        public ErrorMessageModel(int status, string message, Exception exception)
        {
            this.Status = status;
            this.Message = message;
            ExceptionDetails = exception;
        }

        public ErrorMessageModel(int status, ModelStateDictionary modelState)
        {
            this.Status = status;
            Message = "Invalid Request.";
            PendingDetails = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationErrorModel(key, x.ErrorMessage)))
                    .ToList();
        }

    }
}
