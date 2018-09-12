﻿using System.Collections.Generic;
using Forum.Presentation.Contracts.Command;

namespace Forum.Application.Tests.Utils
{

    public class Commands
    {
        public CreateQuestion CreateQuestion { get; set; }
        public AddAnswer AddAnswer { get; set; }
        public AddVote AddVote { get; set; }
    }

    public static class CommandFactory
    {
        public static Commands Build()
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
                    Question = 45,
                    Responder = 6
                },
                AddVote = new AddVote
                {
                    QuestionId = 1,
                    Opinion = true
                }
            };
        }
    }

    
}