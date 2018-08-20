using Framework.Domain;

namespace Forum.Domain.Models.Answers
{
    public interface IAnswerRepository : IRepository<AnswerId, Answer>
    {
    }
}