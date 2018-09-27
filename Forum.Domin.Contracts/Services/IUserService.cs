namespace Forum.Domin.Contracts.Services
{
    public interface IUserService
    {
        bool IsUserValid(long userId);
        string GetUserFullName(long userId);
    }
}
