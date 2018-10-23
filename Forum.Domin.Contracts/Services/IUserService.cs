using System.Collections.Generic;

namespace Forum.Domin.Contracts.Services
{
    public interface IUserService
    {
        bool IsUserValid(long userId);
        string GetUserFullName(long userId);
        List<long> GetVerifireExperts();
    }
}
