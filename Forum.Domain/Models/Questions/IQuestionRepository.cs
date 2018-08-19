using Forum.Domain.Models.Questions.ValueObjects;
using Framework.Domain;

namespace Forum.Domain.Models.Questions
{
    public interface IQuestionRepository : IRepository<QuestionId, Question>
    {
    }
}