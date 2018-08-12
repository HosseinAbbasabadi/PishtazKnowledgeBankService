using Forum.Domain.Models.Questions;
using Forum.Presentation.Contracts;
using Framework.Application.Command;

namespace Forum.Application
{
    public class QuestionCommandHandler : ICommandHandler<CreateQuestion>
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public void Handle(CreateQuestion command)
        {
            var id = _questionRepository.GetNextId("QuestionSeq");
            var questionId = new QuestionId(id);
            var question = new Question(questionId, command.Title, command.Body, command.Tags, command.Creator);
            _questionRepository.Create(question);
        }
    }
}