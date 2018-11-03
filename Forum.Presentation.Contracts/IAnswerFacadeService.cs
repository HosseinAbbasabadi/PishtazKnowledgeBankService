using System.Collections.Generic;
using Forum.Infrastructure.Core;
using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;
using Framework.Identity;

namespace Forum.Presentation.Contracts
{
    public interface IAnswerFacadeService
    {
        void Add(AddAnswer command);
        List<AnswerDto> Answers(long questionId);

        [HasPermission((long) VerifierExpertPermissions.ChooseTrueAnswer)]
        void SetAsChosenAnswer(ChosenAnswer command);
    }
}