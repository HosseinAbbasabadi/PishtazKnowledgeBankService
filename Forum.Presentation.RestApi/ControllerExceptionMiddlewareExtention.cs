using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Forum.Presentation.RestApi
{
    public static class ControllerExceptionMiddlewareExtention
    {
        public static IApplicationBuilder UseControllerExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ControllerExceptionMiddleware>();
        }
    }
}