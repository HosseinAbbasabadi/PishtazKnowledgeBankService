using Framework.Application.Command;

namespace Forum.Presentation.Contracts.Command
{
    public class CreateTag : ICommand
    {
        public string Name { get; set; }
    }
}
