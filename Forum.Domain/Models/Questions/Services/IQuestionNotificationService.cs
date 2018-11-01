using System;
using System.Collections.Generic;
using Forum.Domain.Models.Users;

namespace Forum.Domain.Models.Questions.Services
{
    public interface IQuestionNotificationService
    {
        void RaseQuestionCreatedNotificationToAllRelatedUsers(Question question, List<long> relatedUsers,
            string inquirerName);
    }

    public class QuestionNotificationService : IQuestionNotificationService
    {
        public void RaseQuestionCreatedNotificationToAllRelatedUsers(Question question, List<long> relatedUsers,
            string inquirerName)
        {
            var eventId = Guid.NewGuid();
            foreach (var relatedUser in relatedUsers)
            {
                question.RaseQuestionCreated(eventId, relatedUser, inquirerName);
            }
        }
    }
}