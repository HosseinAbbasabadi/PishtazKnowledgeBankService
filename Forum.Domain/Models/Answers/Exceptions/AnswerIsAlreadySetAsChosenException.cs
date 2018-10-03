using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Domain.Models.Answers.Exceptions
{
    public class AnswerIsAlreadySetAsChosenException : Exception
    {
        public AnswerIsAlreadySetAsChosenException() : base(ExceptionMessages.Message702)
        {
            HResult = 702;
        }
    }
}