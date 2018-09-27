using Forum.Domain.Models.Users.Exceptions;
using Framework.Domain;

namespace Forum.Domain.Models.Users
{
    public class User : EntityBase<UserId>, IAggregateRoot
    {
        public string FullName { get; private set; }

        public User(UserId userid, string fullName) : base(userid)
        {
            GuardAgainsInvalidUser(userid);

            FullName = fullName;
        }

        private static void GuardAgainsInvalidUser(UserId userid)
        {
            if (userid.DbId == 0)
                throw new InvalidUserException();
        }
    }
}