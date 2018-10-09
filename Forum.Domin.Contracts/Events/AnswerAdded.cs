using Forum.Domain.Models.Answers;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Users;
using Framework.Core.Events;

namespace Forum.Domin.Contracts.Events
{
    public class AnswerAdded : DomainEvent
    {
        public QuestionId QuestionId { get; set; }
        public AnswerId AnswerId { get; set; }
        public UserId ResponderId { get; set; }
    }
}