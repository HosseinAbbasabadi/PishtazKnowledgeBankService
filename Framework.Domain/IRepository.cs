using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Framework.Domain
{
    public interface IRepository
    {
    }

    public interface IRepository<in TKey, T> : IRepository where T : IAggregateRoot
    {
        T Get(TKey id);
        List<T> GetAll();
        List<T> Get(Expression<Func<T, bool>> predicate);
        void Create(T aggregate);
        void Delete(T aggregate);
        long GetNextId(string sequenceName);
    }
}