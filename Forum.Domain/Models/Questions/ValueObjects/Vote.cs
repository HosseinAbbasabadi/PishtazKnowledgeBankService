using Forum.Domain.Models.Users;
using Framework.Domain;

namespace Forum.Domain.Models.Questions
{
    public class Vote : ValueObjectBase
    {
        public UserId Voter { get; set; }
    }
}