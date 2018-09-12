using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Users;
using Forum.Presentation.Contracts.Command;
using Framework.Application.Command;

namespace Forum.Application.Command
{
    public class QuestionCommandHandler : ICommandHandler<CreateQuestion>, ICommandHandler<AddVote>
    {
        private readonly IQuestionRepository _questionRepository;
        private const string QuestionSequenceName = "QuestionSeq";

        public QuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public void Handle(CreateQuestion command)
        {
            var id = _questionRepository.GetNextId(QuestionSequenceName);
            var questionId = new QuestionId(id);
            var inquirer = new UserId(5);
            var question = new Question(questionId, command.Title, command.Body, command.Tags, inquirer);
            _questionRepository.Create(question);
        }

        public void Handle(AddVote command)
        {
            var voter = new UserId(5);
            var vote = new Vote(voter, command.Opinion);
            var questionId = new QuestionId(command.QuestionId);
            var question = _questionRepository.Get(questionId);
            question.Vote(vote);
            _questionRepository.Update(question);
        }
    }
}