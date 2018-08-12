using System;

namespace Forum.Domain.Models.Questions.Exceptions
{
    public class TagsAreLessThan3Exception : Exception
    {
        private new const string Message = "Tags Should Not Be Less Than 0";
        public TagsAreLessThan3Exception() : base(Message)
        {
        }
    }
}