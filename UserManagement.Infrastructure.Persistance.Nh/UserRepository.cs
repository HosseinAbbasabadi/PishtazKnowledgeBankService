using System;
using Framework.Nhibernate;
using NHibernate;
using UserManagement.Domain;
using UserManagement.Domain.Models.Users;

namespace UserManagement.Infrastructure.Persistance.Nh
{
    public class UserRepository : BaseRepository<UserId, User>, IUserRepository
    {
        public UserRepository(ISession session) : base(session)
        {
        }
    }
}