using System.Collections.Generic;
using Framework.Core;

namespace Framework.Application.Command
{
    public interface ICommandHandler<in T> : IService
    {
        void Handle(T command);
    }
}