using System.Collections.Generic;
using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;

namespace Forum.Presentation.Contracts
{
    public interface IQuestionFacadeService
    {
        void Create(CreateQuestion command);
        List<QuestionDto> Questions();
        QuestionDetailsDto QuestionDetails(long id);
        void AddVote(AddVote command);
        void ContainsTrueAnswer(ContainsTrueAnswer command);
    }
}
