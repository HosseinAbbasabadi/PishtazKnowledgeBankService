using System;
using Framework.Core.Exceptions;

namespace Forum.Domain.Models.Questions.Exceptions
{
    public class AtLeastOneTagIsRequiredException : BusinessException
    {
        public AtLeastOneTagIsRequiredException() : base("704", ExceptionMessages.Message704)
        {
        }
    }
}