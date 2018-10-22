using System.Collections.Generic;
using Forum.Infrastructure.Core;
using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;
using Framework.Identity;

namespace Forum.Presentation.Contracts
{
    public interface ITagFacadeService
    {
        [HasPermission((long) VerifierExpertPermissions.CreateTag)]
        void Create(CreateTag command);

        List<TagDto> Tags();
    }
}