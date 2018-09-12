using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using Framework.Application.Command;

namespace Framework.Castle
{
    public class ScoppedCommandBusDecorator : ICommandBus
    {
        private readonly ICommandBus _commandBus;
        private readonly IWindsorContainer _container;

        public ScoppedCommandBusDecorator(ICommandBus commandBus, IWindsorContainer container)
        {
            _commandBus = commandBus;
            _container = container;
        }

        public void Dispatch<T>(T command) where T : ICommand
        {
            using (_container.BeginScope())
            {
                _commandBus.Dispatch(command);
            }
        }
    }
}