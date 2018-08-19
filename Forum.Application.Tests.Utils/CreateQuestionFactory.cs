using System.Collections.Generic;
using Forum.Presentation.Contracts;
using Forum.Presentation.Contracts.Command;

namespace Forum.Application.Tests.Utils
{
    public static class CreateQuestionFactory
    {
        public static CreateQuestion Create()
        {
            return new CreateQuestion()
            {
                Title = "some question titlte",
                Body = "some question body",
                Tags = new List<long> {1, 2, 3}
            };
        }
    }
}