using System;
using System.Threading.Tasks;
using Framework.Core;
using Framework.Core.Exceptions;
using Microsoft.AspNetCore.Http;

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
                if (exception is BusinessException)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteJsonAsync(exception.ToString());
                }
                else
                {
                    throw;
                }
            }
        }
    }
}