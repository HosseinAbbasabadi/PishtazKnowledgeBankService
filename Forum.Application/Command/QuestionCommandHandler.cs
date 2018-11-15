using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Questions.Services;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Users;
using Forum.Domin.Contracts.Services;
using Forum.Presentation.Contracts.Command;
using Framework.Application.Command;
using Framework.Core.Events;
using Framework.Identity;

namespace Forum.Application.Command
{
    public class QuestionCommandHandler : ICommandHandler<CreateQuestion>, ICommandHandler<AddVote>,
        ICommandHandler<ContainsTrueAnswer>, ICommandHandler<VerifyQuestion>, ICommandHandler<ModifyQuestion>,
        ICommandHandler<AddView>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IClaimHelper _claimHelper;
        private readonly IEventPublisher _eventPublisher;
        private readonly IUserService _userService;
        private readonly IQuestionNotificationService _questionNotificationService;
        private const string QuestionSequenceName = "QuestionSeq";

        public QuestionCommandHandler(IQuestionRepository questionRepository, IClaimHelper claimHelper,
            IEventPublisher eventPublisher, IUserService userService,
            IQuestionNotificationService questionNotificationService)
        {
            _questionRepository = questionRepository;
            _claimHelper = claimHelper;
            _eventPublisher = eventPublisher;
            _userService = userService;
            _questionNotificationService = questionNotificationService;
        }

        public void Handle(CreateQuestion command)
        {
            var id = _questionRepository.GetNextId(QuestionSequenceName);
            var questionId = new QuestionId(id);
            var inquirerId = _claimHelper.GetCurrentUserId();
            var inquirer = new UserId(inquirerId);
            var question = new Question(questionId, command.Title, command.Body, command.Tags, inquirer,
                _eventPublisher);
            _questionRepository.Create(question);
            //var relatedUsers = _userService.GetVerifireExperts();
            //var inquirerName = _userService.GetUserFullName(inquirerId);
            //_questionNotificationService.RaseQuestionCreatedNotificationToAllRelatedUsers(question, relatedUsers,
            //    inquirerName);
        }

        public void Handle(AddVote command)
        {
            var voterId = _claimHelper.GetCurrentUserId();
            var voter = new UserId(voterId);
            var vote = new Vote(voter, command.Opinion);
            var questionId = new QuestionId(command.QuestionId);
            var question = _questionRepository.Get(questionId);
            question.Vote(vote);
            _questionRepository.Update(question);
        }

        public void Handle(ContainsTrueAnswer command)
        {
            var questionId = new QuestionId(command.QuestionId);
            var question = _questionRepository.Get(questionId);
            question.ContainsTrueAnswser();
            _questionRepository.Update(question);
        }

        public void Handle(VerifyQuestion command)
        {
            var questionId = new QuestionId(command.QuestionId);
            var question = _questionRepository.Get(questionId);
            question.Verify();
            _questionRepository.Update(question);
        }

        public void Handle(ModifyQuestion command)
        {
            var questionId = new QuestionId(command.Id);
            var question = _questionRepository.Get(questionId);
            var modifire = _claimHelper.GetCurrentUserId();
            question.Modify(command.Title, command.Body, command.Tags, modifire);
            _questionRepository.Update(question);
        }

        public void Handle(AddView command)
        {
            var questionId = new QuestionId(command.QuestionId);
            var question = _questionRepository.Get(questionId);
            var currentUserId = _claimHelper.GetCurrentUserId();
            var viewerId = new UserId(currentUserId);
            var view = new View(viewerId);
            question.Visit(view);
            _questionRepository.Update(question);
        }
    }
}