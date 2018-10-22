using Forum.Domain.Models.Questions;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Forum.Infrastructure.Persistance.Nh.Mappings
{
    public class QuestionMapping : ClassMapping<Question>
    {
        public QuestionMapping()
        {
            Table("Questions");
            Lazy(false);

            ComponentAsId(x => x.Id, a => { a.Property(x => x.DbId, x => x.Column("Id")); });
            Component(x => x.Inquirer, a => a.Property(x => x.DbId, x => x.Column("Inquirer")));

            Property(x => x.Title);
            Property(x => x.Body);
            Property(x => x.HasTrueAnswer);
            Property(x => x.CreationDateTime);
            Property(x => x.IsVerified);

            IdBag(a => a.Tags, map =>
            {
                map.Access(Accessor.Field);
                map.Table("QuestionTags");
                map.Key(a => a.Column("QuestionId"));
                map.Id(a =>
                {
                    a.Column("Id");
                    a.Generator(Generators.Guid);
                });
            }, relation => relation.Component(map =>
            {
                map.Access(Accessor.Property);
                map.Property(a => a.DbId, a => a.Column("TagId"));
            }));

            IdBag(a => a.Views, map =>
            {
                map.Access(Accessor.Field);
                map.Table("QuestionViews");
                map.Key(a => a.Column("QuestionId"));
                map.Id(a =>
                {
                    a.Column("Id");
                    a.Generator(Generators.Guid);
                });
            }, relation => relation.Component(map =>
            {
                map.Access(Accessor.Field);
                map.Component(a => a.Viewer, a => a.Property(x => x.DbId, mapper => mapper.Column("ViewerId")));
            }));

            IdBag(a => a.Votes, map =>
            {
                map.Access(Accessor.Field);
                map.Table("QuestionVotes");
                map.Key(a => a.Column("QuestionId"));
                map.Id(a =>
                {
                    a.Column("Id");
                    a.Generator(Generators.Guid);
                });
            }, relation => relation.Component(map =>
            {
                map.Access(Accessor.Field);
                map.Component(a => a.Voter, a => a.Property(x => x.DbId, mapper => mapper.Column("VoterId")));
                map.Property(a => a.Opinion, a => a.Access(Accessor.Property));
            }));
        }
    }
}