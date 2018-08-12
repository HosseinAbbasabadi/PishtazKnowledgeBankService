using System.Collections.Generic;
using System.Text;
using Framework.Domain;

namespace Forum.Domain.Models.Users
{
    public class User : EntityBase<UserId>, IAggregateRoot
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }

        public User(UserId userid, string firstName, string lastName) : base(userid)
        {
            GuardAgainsInvalidUser(userid);

            Firstname = firstName;
            Lastname = lastName;
        }

        private static void GuardAgainsInvalidUser(UserId userid)
        {
            if (userid.DbId == 0)
                throw new InvalidUserException();
        }
    }
}