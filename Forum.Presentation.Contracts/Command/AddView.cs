using Framework.Application.Command;

namespace Forum.Presentation.Contracts.Command
{
    public class AddView : ICommand
    {
        public long QuestionId { get; set; }
    }
}