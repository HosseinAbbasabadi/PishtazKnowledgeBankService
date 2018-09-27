using Forum.Domain.Models.Answers;
using Forum.Presentation.Contracts.Command;
using Framework.Application.Command;
using Framework.Identity;

namespace Forum.Application.Command
{
    public class AnswerCommandHandler : ICommandHandler<AddAnswer>, ICommandHandler<ChosenAnswer>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IClaimHelper _claimHelper;
        private const string AnswerSequenceName = "AnswerSeq";

        public AnswerCommandHandler(IAnswerRepository answerRepository, IClaimHelper claimHelper)
        {
            _answerRepository = answerRepository;
            _claimHelper = claimHelper;
        }

        public void Handle(AddAnswer command)
        {
            var id = _answerRepository.GetNextId(AnswerSequenceName);
            var answerId = new AnswerId(id);
            var responderId = _claimHelper.GetUserId();
            var answer = new Answer(answerId, command.Body, command.Question, responderId);
            _answerRepository.Create(answer);
        }

        public void Handle(ChosenAnswer command)
        {
            var answerId = new AnswerId(command.AnswerId);
            var answer = _answerRepository.Get(answerId);
            answer.SetAsChosenAnswer(_claimHelper.GetUserId(), command.QuestionInquirerId);
            _answerRepository.Update(answer);
        }
    }
}