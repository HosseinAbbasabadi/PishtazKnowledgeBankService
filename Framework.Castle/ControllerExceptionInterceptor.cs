using System;
using Castle.DynamicProxy;
using Framework.Core.Exceptions;

namespace Framework.Castle
{
    public class ControllerExceptionInterceptor : IInterceptor
    {
        private readonly IControllerExceptionTranslator _controllerExceptionTranslator;

        public ControllerExceptionInterceptor(IControllerExceptionTranslator controllerExceptionTranslator)
        {
            _controllerExceptionTranslator = controllerExceptionTranslator;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                _controllerExceptionTranslator.Translate(exception);
            }
        }
    }
}
