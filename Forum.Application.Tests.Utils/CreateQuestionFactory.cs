using System.Collections.Generic;
using Forum.Presentation.Contracts;

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
                Creator = 5,
                Tags = new List<long> {1, 2, 3}
            };
        }
    }
}