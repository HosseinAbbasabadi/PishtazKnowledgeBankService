using Framework.Core;

namespace Framework.Application.Command
{
    public class CommandBus : ICommandBus
    {
        public void Dispatch<T>(T command)
        {
            var handler = ServiceLocator.Current.Resolve<ICommandHandler<T>>();

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