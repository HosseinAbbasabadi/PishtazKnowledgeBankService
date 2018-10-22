using Framework.Application.Command;

namespace Forum.Presentation.Contracts.Command
{
    public class VerifyQuestion : ICommand
    {
        public long QuestionId { get; set; }
    }
}
