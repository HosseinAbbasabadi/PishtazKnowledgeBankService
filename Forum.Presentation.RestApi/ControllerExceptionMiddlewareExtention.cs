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