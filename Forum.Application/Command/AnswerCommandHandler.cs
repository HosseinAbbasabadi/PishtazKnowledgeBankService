using Forum.Domain.Models.Answers;
using Forum.Presentation.Contracts.Command;
using Framework.Application.Command;
using Framework.Identity;

namespace Forum.Application
{
    public class AnswerCommandHandler : ICommandHandler<AddAnswer>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IClaimHelper _cliamHelper;
        private const string AnswerSequenceName = "AnswerSeq";

        public AnswerCommandHandler(IAnswerRepository answerRepository, IClaimHelper cliamHelper)
        {
            _answerRepository = answerRepository;
            _cliamHelper = cliamHelper;
        }

        public void Handle(AddAnswer command)
        {
            var id = _answerRepository.GetNextId(AnswerSequenceName);
            var answerId = new AnswerId(id);
            var responderId = _cliamHelper.GetUserId();
            var answer = new Answer(answerId, command.Body, command.Question, responderId);
            _answerRepository.Create(answer);
        }
    }
}