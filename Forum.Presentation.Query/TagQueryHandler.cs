using System.Collections.Generic;
using Forum.Domain.Models.Tags;
using Forum.Presentation.Contracts.Query;
using Forum.Presentation.Query.Mppers;
using Framework.Application.Query;
using NHibernate;

namespace Forum.Presentation.Query
{
    public class TagQueryHandler : IQueryHandler<List<TagDto>>
    {
        private readonly ISession _session;

        public TagQueryHandler(ISession session)
        {
            _session = session;
        }

        public List<TagDto> Handle()
        {
            var tags = _session.Query<Tag>();
            return TagMapper.MapTags(tags);
        }
    }
} 