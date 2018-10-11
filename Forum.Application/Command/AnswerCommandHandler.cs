using Forum.Domain.Models.Answers;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Presentation.Contracts.Command;
using Framework.Application.Command;
using Framework.Core.Events;
using Framework.Identity;

namespace Forum.Application.Command
{
    public class AnswerCommandHandler : ICommandHandler<AddAnswer>, ICommandHandler<ChosenAnswer>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IClaimHelper _claimHelper;
        private readonly IEventPublisher _eventPublisher;
        private const string AnswerSequenceName = "AnswerSeq";

        public AnswerCommandHandler(IAnswerRepository answerRepository, IClaimHelper claimHelper, IEventPublisher eventPublisher)
        {
            _answerRepository = answerRepository;
            _claimHelper = claimHelper;
            _eventPublisher = eventPublisher;
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
            var questionId = new QuestionId(command.QuestionId);
            var questionAnswers = _answerRepository.GetByQuestionId(questionId);
            var userId = _claimHelper.GetUserId();
            answer.SetAsChosenAnswer(command.QuestionInquirerId, userId, questionAnswers);
            _answerRepository.Update(answer);
        }
    }
}