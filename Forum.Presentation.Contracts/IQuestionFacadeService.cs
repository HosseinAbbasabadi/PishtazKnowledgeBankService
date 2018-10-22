using System.Collections.Generic;
using Forum.Infrastructure.Core;
using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;
using Framework.Identity;

namespace Forum.Presentation.Contracts
{
    public interface IQuestionFacadeService
    {
        void Create(CreateQuestion command);
        List<QuestionDto> Questions();
        QuestionDetailsDto QuestionDetails(long id);
        void AddVote(AddVote command);
        void ContainsTrueAnswer(ContainsTrueAnswer command);

        [HasPermission((long) VerifierExpertPermissions.VerifyQuestion)]
        void VerifyQuestion(VerifyQuestion command);
    }
}