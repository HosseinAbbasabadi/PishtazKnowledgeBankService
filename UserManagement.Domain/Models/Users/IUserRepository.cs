using System;
using System.Collections.Generic;
using System.Text;
using Framework.Domain;

namespace UserManagement.Domain.Models.Users
{
    public interface IUserRepository : IRepository<UserId, User>
    {

    }
}
