using System;

namespace Forum.Domain.Models.Questions.Exceptions
{
    public class TagsAreLessThan3Exception : Exception
    {
        public TagsAreLessThan3Exception() : base(ExceptionMessages.Message704)
        {
            HResult = 704;
        }
    }
}