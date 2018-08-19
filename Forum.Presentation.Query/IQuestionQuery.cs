using System.Collections.Generic;
using Forum.Presentation.Contracts.Query;

namespace Forum.Presentation.Query
{
    public interface IQuestionQuery
    {
        List<QuestionDto> GetQuestions();
        QuestionDetailsDto GetQuestionDetails(long questionId);
    }
}
