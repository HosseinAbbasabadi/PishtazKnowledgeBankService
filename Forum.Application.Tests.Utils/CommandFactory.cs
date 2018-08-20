using System.Collections.Generic;
using Forum.Presentation.Contracts.Command;

namespace Forum.Application.Tests.Utils
{

    public class CommandObjects
    {
        public CreateQuestion CreateQuestion { get; set; }
        public AddAnswer AddAnswer { get; set; }
    }

    public static class CommandFactory
    {
        
        public static CommandObjects Build()
        {
            return new CommandObjects
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
                }
            };
        }
    }

    
}