using System;
using Framework.Core.Exceptions;

namespace Forum.Domain.Models.Questions.Exceptions
{
    public class DuplicateVoteException : BusinessException
    {
        public DuplicateVoteException() : base("703", ExceptionMessages.Message703)
        {
        }
    }
}