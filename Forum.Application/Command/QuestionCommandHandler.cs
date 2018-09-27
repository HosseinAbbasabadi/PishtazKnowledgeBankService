using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Users;
using Forum.Presentation.Contracts.Command;
using Framework.Application.Command;
using Framework.Identity;

namespace Forum.Application.Command
{
    public class QuestionCommandHandler : ICommandHandler<CreateQuestion>, ICommandHandler<AddVote>, ICommandHandler<ContainsTrueAnswer>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IClaimHelper _claimHelper;
        private const string QuestionSequenceName = "QuestionSeq";

        public QuestionCommandHandler(IQuestionRepository questionRepository, IClaimHelper claimHelper)
        {
            _questionRepository = questionRepository;
            _claimHelper = claimHelper;
        }

        public void Handle(CreateQuestion command)
        {
            var id = _questionRepository.GetNextId(QuestionSequenceName);
            var questionId = new QuestionId(id);
            var inquirerId = _claimHelper.GetUserId();
            var inquirer = new UserId(inquirerId);
            var question = new Question(questionId, command.Title, command.Body, command.Tags, inquirer);
            _questionRepository.Create(question);
        }

        public void Handle(AddVote command)
        {
            var voterId = _claimHelper.GetUserId();
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
    }
}