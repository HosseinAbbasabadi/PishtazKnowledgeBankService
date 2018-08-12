using System.Collections.Generic;

namespace Framework.Core
{
    public interface IBuilder<T>
    {
        T Build();
        List<T> BuildList(int count);
    }
}