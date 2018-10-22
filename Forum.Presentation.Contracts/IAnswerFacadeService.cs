using System.Collections.Generic;
using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;

namespace Forum.Presentation.Contracts
{
    public interface IAnswerFacadeService
    {
        void Add(AddAnswer command);
        List<AnswerDto> Answers(long questionId);
        void SetAsChosenAnswer(ChosenAnswer command);
    }
}
