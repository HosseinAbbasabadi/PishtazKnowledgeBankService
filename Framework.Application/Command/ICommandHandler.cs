﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Core;

namespace Framework.Application.Command
{
    public interface ICommandHandler<in T> : IService where T : ICommand
    {
        void Handle(T command);
    }
}