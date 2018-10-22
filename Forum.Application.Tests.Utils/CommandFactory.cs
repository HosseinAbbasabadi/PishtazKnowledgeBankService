using System.Collections.Generic;
using Forum.Presentation.Contracts.Command;

namespace Forum.Application.Tests.Utils
{
    public class Commands
    {
        public CreateQuestion CreateQuestion { get; set; }
        public AddAnswer AddAnswer { get; set; }
        public AddVote AddVote { get; set; }
        public ChosenAnswer ChosenAnswer { get; set; }
        public ContainsTrueAnswer ContainsTrueAnswer { get; set; }
        public CreateTag CreateTag { get; set; }
        public VerifyQuestion VerifyQuestion { get; set; }
    }

    public static class CommandFactory
    {
        public static Commands BuildACommandOfType()
        {
            return new Commands
            {
                CreateQuestion = new CreateQuestion
                {
                    Title = "some question titlte",
                    Body = "some question body",
                    Tags = new List<long> {1, 2, 3}
                },
                AddAnswer = new AddAnswer
                {
                    Body = "some body",
                    Question = 45
                },
                AddVote = new AddVote
                {
                    QuestionId = 1,
                    Opinion = true
                },
                ChosenAnswer = new ChosenAnswer
                {
                    AnswerId = 5,
                    QuestionId = 6
                },
                ContainsTrueAnswer = new ContainsTrueAnswer
                {
                    QuestionId = 6
                },
                CreateTag = new CreateTag
                {
                    Name = "some name"
                },
                VerifyQuestion = new VerifyQuestion
                {
                    QuestionId = 6
                }
            };
        }
    }
}