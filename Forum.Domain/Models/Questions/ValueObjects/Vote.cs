using Forum.Domain.Models.Users;
using Framework.Domain;

namespace Forum.Domain.Models.Questions.ValueObjects
{
    public class Vote : ValueObjectBase
    {
        public UserId Voter { get; private set; }
        public bool Opinion { get; private set; }

        protected Vote()
        {
        }

        public Vote(UserId voter, bool opinion)
        {
            Voter = voter;
            Opinion = opinion;
        }
    }
}