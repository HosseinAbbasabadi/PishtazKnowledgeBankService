using Framework.Domain;

namespace Forum.Domain.Models.Questions.ValueObjects
{
    public class Vote : ValueObjectBase
    {
        public long Voter { get; private set; }
        public bool Like { get; private set; }

        protected Vote()
        {
        }

        public Vote(long voter, bool like)
        {
            Voter = voter;
            Like = like;
        }
    }
}