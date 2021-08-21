using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BilgeKitap.Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }


        //Eğer bir hata olursa  InternalServerError hatası ver
        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
           
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";
            IEnumerable<ValidationFailure> errors;
            //Eğer Validation hatası ise
            if (e.GetType() == typeof(ValidationException))
            {
                message = e.Message;
                errors = ((ValidationException)e).Errors;
                httpContext.Response.StatusCode = 400;
                return httpContext.Response.WriteAsync(new ValidationErrorDetails
                {
                    StatusCode = 400,
                    Message=message,
                    Errors=errors
                }.ToString()); 
            }
            //Eğer sistem hata verirse bunu döndürüyor.Sistemsel hatalar için.
            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
