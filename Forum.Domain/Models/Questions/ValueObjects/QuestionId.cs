using Framework.Domain;

namespace Forum.Domain.Models.Questions.ValueObjects
{
    public class QuestionId : IdBase<long>
    {
        protected QuestionId() { }
        public QuestionId(long idDbId) : base(idDbId)
        {
        }
    }
}