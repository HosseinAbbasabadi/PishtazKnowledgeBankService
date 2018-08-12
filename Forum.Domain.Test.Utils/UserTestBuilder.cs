using System;
using System.Collections.Generic;
using Forum.Domain.Models.Users;
using Framework.Core;

namespace Forum.Domain.Test.Utils
{
    public class UserTestBuilder : IBuilder<User>
    {
        public long Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }

        public UserTestBuilder()
        {
            Id = 1;
            Firstname = "sepehr";
            Lastname = "pakpoor";
        }

        public UserTestBuilder WithId(long id)
        {
            Id = id;
            return this;
        }

        public UserTestBuilder WithFirstname(string firstname)
        {
            Firstname = firstname;
            return this;
        }

        public UserTestBuilder WithLastname(string lastname)
        {
            Lastname = lastname;
            return this;
        }

        public User Build()
        {
            var userId = new UserId(Id);
            return new User(userId, Firstname, Lastname);
        }

        public List<User> BuildList(int count)
        {
            throw new NotImplementedException();
        }
    }
}