using Forum.Domain.Models.Answers;
using Forum.Presentation.Contracts.Command;
using Framework.Application.Command;

namespace Forum.Application
{
    public class AnswerCommandHandler : ICommandHandler<AddAnswer>
    {
        private readonly IAnswerRepository _answerRepository;
        private const string AnswerSequenceName = "AnswerSeq";

        public AnswerCommandHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public void Handle(AddAnswer command)
        {
            var id = _answerRepository.GetNextId(AnswerSequenceName);
            var answerId = new AnswerId(id);
            var answer = new Answer(answerId, command.Body, command.Question, command.Responder);
            _answerRepository.Create(answer);
        }
    }
}