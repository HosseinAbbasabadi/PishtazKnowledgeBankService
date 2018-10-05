using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Domain.Models.Answers.Exceptions
{
    public class QuestionAlreadyHasAChosenAnswerException : Exception
    {
        public QuestionAlreadyHasAChosenAnswerException() : base(ExceptionMessages.Message705)
        {
            HResult = 705;
        }
    }
}
