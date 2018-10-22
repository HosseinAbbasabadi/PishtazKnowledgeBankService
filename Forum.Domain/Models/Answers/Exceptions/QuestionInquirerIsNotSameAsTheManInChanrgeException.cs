using System;
using Framework.Core.Exceptions;

namespace Forum.Domain.Models.Answers.Exceptions
{
    public class QuestionInquirerIsNotSameAsTheManInChanrgeException : BusinessException
    {
        public QuestionInquirerIsNotSameAsTheManInChanrgeException() : base("701", ExceptionMessages.Message701)
        {
        }
    }
}