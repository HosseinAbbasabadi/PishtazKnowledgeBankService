using Framework.Application.Command;

namespace Forum.Presentation.Contracts.Command
{
    public class ChosenAnswer : ICommand
    {
        public long AnswerId { get; set; }
        public long QuestionInquirerId { get; set; }
    }
}
