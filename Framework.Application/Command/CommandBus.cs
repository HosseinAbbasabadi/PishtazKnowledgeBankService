using Framework.Core;

namespace Framework.Application.Command
{
    public class CommandBus : ICommandBus
    {
        public void Dispatch<T>(T command) where T : ICommand
        {
            var handler = ServiceLocator.Current.Resolve<TransactionalCommandHandlerDecorator<T>>();

            try
            {
                handler.Handle(command);
            }
            finally
            {
                ServiceLocator.Current.Release(handler);
            }
        }
    }
}