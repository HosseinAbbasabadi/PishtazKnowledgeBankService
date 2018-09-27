using Framework.Application.Command;

namespace Forum.Presentation.Contracts.Command
{
    public class ContainsTrueAnswer : ICommand
    {
        public long QuestionId { get; set; }
    }
}