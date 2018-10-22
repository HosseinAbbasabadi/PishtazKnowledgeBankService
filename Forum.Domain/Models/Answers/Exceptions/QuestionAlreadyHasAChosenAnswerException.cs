using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Exceptions;

namespace Forum.Domain.Models.Answers.Exceptions
{
    public class QuestionAlreadyHasAChosenAnswerException : BusinessException
    {
        public QuestionAlreadyHasAChosenAnswerException() : base("705", ExceptionMessages.Message705)
        {
        }
    }
}