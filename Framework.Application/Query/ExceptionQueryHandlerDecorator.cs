using System;

namespace Framework.Application.Query
{
    public class ExceptionQueryHandlerDecorator<T,TU>: IQueryHandler<T,TU>
    {
        private readonly IQueryHandler<T, TU> _queryHandler;

        public ExceptionQueryHandlerDecorator(IQueryHandler<T, TU> queryHandler)
        {
            _queryHandler = queryHandler;
        }

        public T Handle(TU condition)
        {
            try
            {
                return _queryHandler.Handle(condition);
            }
            catch (Exception exception)
            {
                //TODO: Log exception here
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
