using Forum.Domain.Models.Questions;
using NHibernate.Mapping.ByCode.Conformist;

namespace Forum.Infrastructure.Persistance.Nh.Mappings
{
    public class QuestionMapping : ClassMapping<Question>
    {
        public QuestionMapping()
        {
            Table("Questions");
            Lazy(false);
        }
    }
}