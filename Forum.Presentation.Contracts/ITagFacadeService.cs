using System.Collections.Generic;
using Forum.Presentation.Contracts.Command;
using Forum.Presentation.Contracts.Query;

namespace Forum.Presentation.Contracts
{
    public interface ITagFacadeService
    {
        void Create(CreateTag command);
        List<TagDto> Tags();
    }
}
