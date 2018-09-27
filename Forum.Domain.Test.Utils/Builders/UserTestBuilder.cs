using System;
using System.Collections.Generic;
using Forum.Domain.Models.Users;
using Framework.Core;

namespace Forum.Domain.Test.Utils.Builders
{
    public class UserTestBuilder : IBuilder<User>
    {
        public long Id { get; private set; }
        public string FullName { get; private set; }

        public UserTestBuilder()
        {
            Id = 1;
            FullName = "سپهر پاکپور";
        }

        public UserTestBuilder WithId(long id)
        {
            Id = id;
            return this;
        }

        public UserTestBuilder WithFirstname(string firstname)
        {
            FullName = firstname;
            return this;
        }


        public User Build()
        {
            var userId = new UserId(Id);
            return new User(userId, FullName);
        }

        public List<User> BuildList(int count)
        {
            throw new NotImplementedException();
        }
    }
}