using System;

namespace Framework.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public string Code { get; private set; }

        public BusinessException(string code, string message) : base(message)
        {
            this.Code = code;
        }

        public override string ToString()
        {
            return string.Format("{0} -- {1}", this.Code, this.Message);
        }
    }
}