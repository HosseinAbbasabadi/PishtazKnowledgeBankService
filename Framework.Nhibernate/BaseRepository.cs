using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework.Domain;
using NHibernate;

namespace Framework.Nhibernate
{
    public class BaseRepository<TKey, T> : IRepository<TKey, T> where T : IAggregateRoot
    {
        private readonly ISession _session;

        public BaseRepository(ISession session)
        {
            _session = session;
        }

        public void Create(T aggregate)
        {
            _session.Save(aggregate);
        }

        public void Update(T aggregate)
        {
            _session.Update(aggregate);
        }

        public void Delete(T aggregate)
        {
            _session.Delete(aggregate);
        }

        public T Get(TKey id)
        {
            return _session.Get<T>(id);
        }

        public List<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _session.Query<T>().Where(predicate).ToList();
        }

        public List<T> GetAll()
        {
            return _session.Query<T>().ToList();
        }

        public long GetNextId(string sequenceName)
        {
            return _session.GetNextSequence(sequenceName);
        }
    }
}