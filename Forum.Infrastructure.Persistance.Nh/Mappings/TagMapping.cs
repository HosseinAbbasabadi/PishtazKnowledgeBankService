using Forum.Domain.Models.Tags;
using NHibernate.Mapping.ByCode.Conformist;

namespace Forum.Infrastructure.Persistance.Nh.Mappings
{
    public class TagMapping: ClassMapping<Tag>
    {
        public TagMapping()
        {
            Table("Tags");
            Lazy(false);

            ComponentAsId(a=>a.Id, x=> {x.Property(a=>a.DbId, mapper => mapper.Column("Id"));});

            Property(a=>a.Name);
            Property(a=>a.CreationDateTime);
        }
    }
}
