using Framework.Application.Command;

namespace Forum.Presentation.Contracts.Command
{
    public class AddAnswer : ICommand
    {
        public string Body { get; set; }
        public long Question { get; set; }
    }
}