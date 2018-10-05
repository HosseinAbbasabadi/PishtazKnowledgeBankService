using System;

namespace Framework.Core.Exceptions
{
    public class ControllerExceptionTranslator : IControllerExceptionTranslator
    {
        public ErrorDetails Translate(Exception exception)
        {
            var error = new ErrorDetails
            {
                Message = exception.Message,
                StatusCode = exception.HResult
            };
            return error;
        }
    }
}