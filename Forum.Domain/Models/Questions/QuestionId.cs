using Framework.Domain;

namespace Forum.Domain.Models.Questions
{
    public class QuestionId : IdBase<long>
    {
        public QuestionId(long idDbId) : base(idDbId)
        {
        }
    }
}