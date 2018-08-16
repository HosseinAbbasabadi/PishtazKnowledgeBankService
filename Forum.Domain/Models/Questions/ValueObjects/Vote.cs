using Framework.Domain;

namespace Forum.Domain.Models.Questions.ValueObjects
{
    public class Vote : ValueObjectBase
    {
        public long Voter { get; private set; }
        public bool Opinion { get; private set; }

        protected Vote()
        {
        }

        public Vote(long voter, bool opinion)
        {
            Voter = voter;
            Opinion = opinion;
        }
    }
}