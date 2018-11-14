using System;
using System.Collections.Generic;
using Forum.Domain.Models.Questions;
using Forum.Domain.Models.Questions.ValueObjects;
using Forum.Domain.Models.Users;
using Framework.Core;
using Framework.Core.Clock;
using Framework.Core.Events;

namespace Forum.Domain.Test.Utils.Builders
{
    public class QuestionTestBuilder : IBuilder<Question>
    {
        public QuestionId Id { get; private set; }
        public string Title { get; private set; }
        public string Body { get; private set; }
        public UserId Inquirer { get; private set; }
        public DateTime CreationDate { get; private set; }
        public List<long> Tags { get; private set; }
        public bool IsVerified { get; private set; }
        public IEventPublisher EventPublisher { get; set; }

        public QuestionTestBuilder()
        {
            var clock = new Clock();
            Id = new QuestionId(1);
            Title = "how to ?";
            Body = "the description";
            Tags = new List<long> {1, 2, 3};
            Inquirer = new UserId(2);
            IsVerified = false;
            CreationDate = clock.PastDateTime();
            EventPublisher = new FakePublisher();
        }

        public QuestionTestBuilder WithId(long id)
        {
            Id = new QuestionId(id);
            return this;
        }

        public QuestionTestBuilder WithTitle(string title)
        {
            Title = title;
            return this;
        }

        public QuestionTestBuilder WithBody(string body)
        {
            Body = body;
            return this;
        }

        public QuestionTestBuilder WithTags(List<long> tags)
        {
            Tags = tags;
            return this;
        }

        //public QuestionTestBuilder WithCreator(long creator)
        //{
        //    Creator = creator;
        //    return this;
        //}

        //public QuestionTestBuilder WithCurrectAnswer(CurrectAnswer currectAnswer)
        //{
        //    CurrectAnswer = currectAnswer;
        //    return this;
        //}

        public QuestionTestBuilder WithEventPublisher(IEventPublisher eventPublisher)
        {
            EventPublisher = eventPublisher;
            return this;
        }

        public Question BuildWithVotes(List<Vote> votes)
        {
            var question = Build();
            votes.ForEach(vote => { question.Vote(vote); });
            return question;
        }

        public Question BuildWithViews(List<View> views)
        {
            var question = Build();
            views.ForEach(view => question.Visit(view));
            return question;
        }

        public Question Build()
        {
            return new Question(Id, Title, Body, Tags, Inquirer, EventPublisher);
        }

        public List<Question> BuildList(int count)
        {
            var questions = new List<Question>();
            for (var i = 0; i <= count; i++)
            {
                questions.Add(Build());
            }

            return questions;
        }
    }
}