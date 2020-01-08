using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSystemWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceSystemWebAPI
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext ExContext)
        {
            string exceptionmsg = ExContext.Exception.InnerException != null ? ExContext.Exception.InnerException.Message
                            : ExContext.Exception.Message;
            ObjectResult oResult = new ObjectResult(null);
            string exceptionname = ExContext.Exception.InnerException != null ? ExContext.Exception.InnerException.GetType().Name
                            : ExContext.Exception.GetType().Name;
            switch (exceptionname)
            {
                case "NotAuthorizedException":
                    oResult.StatusCode = 403;
                    oResult.Value = new ErrorResponseModel(403, exceptionmsg);
                    break;
                case "ResourceNotFoundException":
                    oResult.StatusCode = 404;
                    oResult.Value = new ErrorResponseModel(404, exceptionmsg);
                    break;
                default:
                    oResult.StatusCode = 500;
                    oResult.Value = new ErrorResponseModel(500, "Something went wrong contact your system admin.", ExContext.Exception);
                    break;
            }
            ExContext.Result = oResult;
        }
    }
}
