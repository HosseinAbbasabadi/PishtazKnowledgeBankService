using System;

namespace Forum.Domain.Models.Questions.Exceptions
{
    public class DuplicateVoteException : Exception
    {
        public DuplicateVoteException() : base(ExceptionMessages.Message703)
        {
            HResult = 703;
        }
    }
}