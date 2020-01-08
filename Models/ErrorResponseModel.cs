using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystemWebAPI.Models
{
    public class ErrorResponseModel
    {
        public ErrorMessageModel Error { get; set; }

        public ErrorResponseModel(ErrorMessageModel error)
        {
            Error = error;
        }

        public ErrorResponseModel(int status, ModelStateDictionary modelState)
        {
            Error = new ErrorMessageModel(status, modelState);
        }

        public ErrorResponseModel(int status, string message)
        {
            Error = new ErrorMessageModel(status, message);
        }

        public ErrorResponseModel(int status, string message, Exception exception)
        {
            Error = new ErrorMessageModel(status, message, exception);
        }

    }
}
