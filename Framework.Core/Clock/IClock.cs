using System;

namespace Framework.Core.Clock
{
    public interface IClock
    {
        DateTime FutureDateTime();
        DateTime PastDateTime();
    }
}
