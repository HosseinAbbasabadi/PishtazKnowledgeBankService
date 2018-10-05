using System;
using System.Collections.Generic;
using Forum.Domain.Models.Answers;
using Framework.Core;

namespace Forum.Domain.Test.Utils.Builders
{
    public class AnswerTestBuilder : IBuilder<Answer>
    {
        public long QuestionInquirer = 5;
        public long PersonWhoIsSettingTheAnswerAsChosen = 5;
        public AnswerId Id { get; private set; }
        public string Body { get; private set; }
        public long Responder { get; private set; }
        public long Question { get; private set; }

        public AnswerTestBuilder()
        {
            Id = new AnswerId(2);
            Body = "Some Answer Text";
            Responder = 6;
            Question = 83;
        }

        public AnswerTestBuilder WithId(long id)
        {
            var answerId = new AnswerId(id);
            Id = answerId;
            return this;
        }

        public AnswerTestBuilder WithDifferentQuestionInquirerAndPersonWhoIsSettingTheAnswerAsChosen()
        {
            QuestionInquirer = 10;
            PersonWhoIsSettingTheAnswerAsChosen = 16;
            return this;
        }

        public Answer BuildChosenAnswer()
        {
            var answer = Build();
            var answersOfSpecificQuestion = BuildList(3);
            answer.SetAsChosenAnswer(QuestionInquirer, PersonWhoIsSettingTheAnswerAsChosen, answersOfSpecificQuestion);
            return answer;
        }

        public Answer Build()
        {
            return new Answer(Id, Body, Question, Responder);
        }

        public List<Answer> BuildList(int count)
        {
            var answers = new List<Answer>();
            for (var i = 0; i < count; i++)
            {
                answers.Add(Build());
            }

            return answers;
        }
    }
}