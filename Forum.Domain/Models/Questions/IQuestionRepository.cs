using System;
using System.Collections.Generic;
using System.Text;
using Framework.Domain;

namespace Forum.Domain.Models.Questions
{
    public interface IQuestionRepository : IRepository<QuestionId, Question>
    {
    }
}