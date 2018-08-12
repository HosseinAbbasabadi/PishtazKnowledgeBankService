using System.Collections.Generic;

namespace Framework.Application.Query
{
    public interface IQueryHandler<out T, in TU> // where T: List<IQuery>, IQuery
    {
        //T Handle(object condition);
        T Handle(TU condition);
    }
}