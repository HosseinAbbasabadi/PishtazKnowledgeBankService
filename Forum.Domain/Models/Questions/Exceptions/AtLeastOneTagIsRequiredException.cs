using System;

namespace Forum.Domain.Models.Questions.Exceptions
{
    public class AtLeastOneTagIsRequiredException : Exception
    {
        public AtLeastOneTagIsRequiredException() : base(ExceptionMessages.Message704)
        {
            HResult = 704;
        }
    }
}