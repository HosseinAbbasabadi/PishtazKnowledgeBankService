using System;

namespace Framework.Core.Clock
{
    public class Clock : IClock
    {
        public DateTime FutureDateTime()
        {
            return new DateTime(2200,1,10,5,36,59);
        }

        public DateTime PastDateTime()
        {
            return new DateTime(2005,1,10,5,36,59);
        }
    }
}