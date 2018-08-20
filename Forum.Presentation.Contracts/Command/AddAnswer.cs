using System;
using System.Collections.Generic;
using System.Text;
using Framework.Application.Command;

namespace Forum.Presentation.Contracts.Command
{
    public class AddAnswer : ICommand
    {
        public string Body { get; set; }
        public long Question { get; set; }
        public long Responder { get; set; }
    }
}