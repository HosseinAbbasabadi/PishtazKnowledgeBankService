using Framework.Domain;

namespace Forum.Domain.Models.Answers
{
    public class AnswerId : IdBase<long>
    {
        protected AnswerId()
        {
            
        }
        public AnswerId(long idDbId) : base(idDbId)
        {
        }
    }
}