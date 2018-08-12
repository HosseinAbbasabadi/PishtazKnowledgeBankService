using System;
using System.Collections.Generic;
using Forum.Domain.Models.Questions;
using Framework.Core;
using Framework.Core.Clock;

namespace Forum.Domain.Test.Utils
{
    public class QuestionTestBuilder : IBuilder<Question>
    {
        public QuestionId Id { get; set; }
        public string Title { get; private set; }
        public string Body { get; private set; }
        public long Creator { get; private set; }
        public DateTime CreationDate { get; set; }
        public List<long> Tags { get; private set; }
        public CurrectAnswer CurrectAnswer { get; private set; }

        public QuestionTestBuilder()
        {
            var clock = new Clock();
            Id = new QuestionId(1);
            Title = "how to ?";
            Body = "the description";
            Tags = new List<long> {1, 2, 3};
            Creator = 12;
            CreationDate = clock.PastDateTime();
            CurrectAnswer = null;
        }

        //public QuestionTestBuilder WithTitle(string title)
        //{
        //    Title = title;
        //    return this;
        //}

        //public QuestionTestBuilder WithBody(string body)
        //{
        //    Body = body;
        //    return this;
        //}

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

        public Question Build()
        {
            return new Question(Id,Title, Body, Tags, Creator);
        }

        public List<Question> BuildList(int count)
        {
            throw new NotImplementedException();
        }
    }
}