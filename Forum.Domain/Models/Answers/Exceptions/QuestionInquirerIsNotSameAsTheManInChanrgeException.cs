using System;

namespace Forum.Domain.Models.Answers.Exceptions
{
    public class QuestionInquirerIsNotSameAsTheManInChanrgeException : Exception
    {
        public QuestionInquirerIsNotSameAsTheManInChanrgeException() : base(ExceptionMessages.Message701)
        {
            HResult = 701;
        }
    }
}