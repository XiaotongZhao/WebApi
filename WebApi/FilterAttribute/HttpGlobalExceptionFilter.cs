using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace WebApi.FilterAttribute
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        readonly IHostEnvironment env;

        public HttpGlobalExceptionFilter(IHostEnvironment env)
        {
            this.env = env;
        }

        public void OnException(ExceptionContext context)
        {

            var json = new ErrorResponse(context.Exception.Message);

            if (env.IsDevelopment()) json.DeveloperMessage = context.Exception;

            context.Result = new ApplicationErrorResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            context.ExceptionHandled = true;
        }
    }

    public class ApplicationErrorResult : ObjectResult
    {
        public ApplicationErrorResult(object value) : base(value)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }

    public class ErrorResponse
    {
        public ErrorResponse(string msg)
        {
            Message = msg;
        }
        public string Message { get; set; }
        public object DeveloperMessage { get; set; }
    }
}
