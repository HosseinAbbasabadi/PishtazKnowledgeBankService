using System;
using System.Collections.Generic;
using System.Text;
using Forum.Presentation.Contracts.Query;

namespace Forum.Presentation.Query
{
    public interface IQuestionQuery
    {
        List<QuestionDto> GetQuestions();
    }
}
