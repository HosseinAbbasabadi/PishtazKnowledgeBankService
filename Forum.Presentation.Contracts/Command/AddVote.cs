using Framework.Application.Command;

namespace Forum.Presentation.Contracts.Command
{
    public class AddVote : ICommand
    {
        public long QuestionId { get; set; }
        public bool Opinion { get; set; }
    }
}
