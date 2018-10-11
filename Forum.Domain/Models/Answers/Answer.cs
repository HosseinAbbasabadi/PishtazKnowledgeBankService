using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Domain.Models.Answers.Exceptions;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Users;
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

        public Answer(AnswerId id, string body, long question, long responder, IEventPublisher publisher) : base(id)
        {
            Body = body;
            Question = new QuestionId(question);
            Responder = new UserId(responder);
            IsChosen = false;
            CreationDateTime = DateTime.Now;
            publisher.Publish(new AnswerAdded);
        }

        public void SetAsChosenAnswer(long questionInquirer, long manInCharge, List<Answer> questionAnswers)
        {
            if(QuestionHasAlreadyAChosenAnswer(questionAnswers))
                throw new QuestionAlreadyHasAChosenAnswerException();
            if(IsChosen)
                throw new AnswerIsAlreadySetAsChosenException();
            if(!questionInquirer.Equals(manInCharge))
                throw new QuestionInquirerIsNotSameAsTheManInChanrgeException();
            IsChosen = true;
        }

        private static bool QuestionHasAlreadyAChosenAnswer(IEnumerable<Answer> questionAnswers)
        {
            return questionAnswers.Any(z=>z.IsChosen);
        }
    }
}