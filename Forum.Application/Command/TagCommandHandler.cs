using Forum.Domain.Models.Tags;
using Forum.Presentation.Contracts.Command;
using Framework.Application.Command;

namespace Forum.Application.Command
{
    public class TagCommandHandler : ICommandHandler<CreateTag>
    {
        private readonly ITagRepository _tagRepository;
        private const string TagSequenceName = "TagSeq";
        public TagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public void Handle(CreateTag command)
        {
            var id = _tagRepository.GetNextId(TagSequenceName);
            var tagId = new TagId(id);
            var tag = new Tag(tagId, command.Name);
            _tagRepository.Create(tag);
        }
    }
}