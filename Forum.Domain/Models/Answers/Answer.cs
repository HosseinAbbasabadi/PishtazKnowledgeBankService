using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Domain.Models.Answers.Exceptions;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Users;
using Forum.DomainEvents;
using Framework.Core.Events;
using Framework.Domain;

namespace Forum.Domain.Models.Answers
{
    public class Answer : AggregateRootBase<AnswerId>
    {
        public string Body { get; private set; }
        public QuestionId Question { get; private set; }
        public UserId Responder { get; private set; }
        public bool IsChosen { get; private set; }

        protected Answer()
        {
        }

        public Answer(AnswerId id, string body, long question, long responder, IEventPublisher eventPublisher) : base(
            id, eventPublisher)
        {
            Body = body;
            Question = new QuestionId(question);
            Responder = new UserId(responder);
            IsChosen = false;
            CreationDateTime = DateTime.Now;
        }

        public void RaseAnswerAdded(long relatedUser, string questionTitle, string responderName)
        {
            var @event = new AnswerAdded(Guid.NewGuid(), relatedUser, Question.DbId, questionTitle, responderName);
            EventPublisher.Publish(@event);
        }

        public void SetAsChosenAnswer(long questionInquirer, List<Answer> questionAnswers)
        {
            if (QuestionHasAlreadyAChosenAnswer(questionAnswers))
                throw new QuestionAlreadyHasAChosenAnswerException();
            if (IsChosen)
                throw new AnswerIsAlreadySetAsChosenException();
            IsChosen = true;
        }

        private static bool QuestionHasAlreadyAChosenAnswer(IEnumerable<Answer> questionAnswers)
        {
            return questionAnswers.Any(z => z.IsChosen);
        }
    }
}