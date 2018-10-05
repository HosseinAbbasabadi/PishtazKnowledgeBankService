using System;

namespace Framework.Core.Exceptions
{
    public interface IControllerExceptionTranslator
    {
        ErrorDetails Translate(Exception exception);
    }
}
