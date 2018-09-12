using Forum.Domain.Models.Answers;
using NHibernate.Mapping.ByCode.Conformist;

namespace Forum.Infrastructure.Persistance.Nh.Mappings
{
    public class AnswerMapping : ClassMapping<Answer>
    {
        public AnswerMapping()
        {
            Table("Answers");
            Lazy(false);

            Property(x => x.Body);
            Property(x => x.IsChosen);
            Property(x => x.CreationDateTime);
            ComponentAsId(a => a.Id, x => { x.Property(a => a.DbId, a => a.Column("Id")); });
            Component(a => a.Question, x => { x.Property(a => a.DbId, a => a.Column("Question")); });
            Component(a => a.Responder, x => { x.Property(a => a.DbId, a => a.Column("Responder")); });
        }
    }
}