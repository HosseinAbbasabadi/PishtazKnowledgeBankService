using System.Collections.Generic;
using Forum.Domain.Models.Questions.ValueObjects;
using Framework.Domain;

namespace Forum.Domain.Models.Answers
{
    public interface IAnswerRepository : IRepository<AnswerId, Answer>
    {
        List<Answer> GetByQuestionId(QuestionId questionId);
    }
}