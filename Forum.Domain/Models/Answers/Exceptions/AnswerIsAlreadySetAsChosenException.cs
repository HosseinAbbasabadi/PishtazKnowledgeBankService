using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Exceptions;

namespace Forum.Domain.Models.Answers.Exceptions
{
    public class AnswerIsAlreadySetAsChosenException : BusinessException
    {
        public AnswerIsAlreadySetAsChosenException() : base("702", ExceptionMessages.Message702)
        {
        }
    }
}