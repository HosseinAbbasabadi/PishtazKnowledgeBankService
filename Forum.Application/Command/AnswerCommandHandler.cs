using Forum.Domain.Models.Answers;
using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.DomainEvents;
using Forum.Domin.Contracts.Services;
using Forum.Infrastructure.ACL.NotificationSystem;
using Forum.Presentation.Contracts.Command;
using Framework.Application.Command;
using Framework.Core.Events;
using Framework.Identity;

namespace Forum.Application.Command
{
    public class AnswerCommandHandler : ICommandHandler<AddAnswer>, ICommandHandler<ChosenAnswer>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserService _userService;
        private readonly IClaimHelper _claimHelper;
        private readonly IEventPublisher _eventPublisher;
        private readonly IEventListener _eventListener;
        private const string AnswerSequenceName = "AnswerSeq";

        public AnswerCommandHandler(IAnswerRepository answerRepository, IClaimHelper claimHelper,
            IEventPublisher eventPublisher, IEventListener eventListener, IQuestionRepository questionRepository,
            IUserService userService)
        {
            _answerRepository = answerRepository;
            _claimHelper = claimHelper;
            _eventPublisher = eventPublisher;
            _eventListener = eventListener;
            _questionRepository = questionRepository;
            _userService = userService;
        }

        public void Handle(AddAnswer command)
        {
            var id = _answerRepository.GetNextId(AnswerSequenceName);
            var answerId = new AnswerId(id);
            var responderId = _claimHelper.GetUserId();
            var answer = new Answer(answerId, command.Body, command.Question, responderId, _eventPublisher);
            _answerRepository.Create(answer);
            _eventListener.Listen(new PushNotificationEventHandler<AnswerAdded>());
            var question = _questionRepository.Get(new QuestionId(command.Question));
            var responderName = _userService.GetUserFullName(responderId);
            answer.RaseAnswerAdded(question.Inquirer.DbId, question.Title, responderName);
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