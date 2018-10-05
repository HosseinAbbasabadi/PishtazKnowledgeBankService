using System;
using System.Net;
using System.Threading.Tasks;
using Framework.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Presentation.RestApi
{
    public class ControllerExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ControllerExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var error = new ErrorDetails
                {
                    Message = exception.Message,
                    StatusCode = exception.HResult
                };
                
                context.Response.StatusCode = 400;
                await context.Response.WriteJsonAsync(error);
            }
        }
    }
}
