using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Users;
using Forum.Presentation.Contracts.Command;
using Framework.Application.Command;

namespace Forum.Application
{
    public class QuestionCommandHandler : ICommandHandler<CreateQuestion>
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
    }
}