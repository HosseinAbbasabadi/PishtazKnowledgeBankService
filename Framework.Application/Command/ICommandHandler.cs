using System.Collections.Generic;

namespace Framework.Application.Command
{
    public interface ICommandHandler<in T> // where T : ICommand
    {
        void Handle(T command);
    }
}