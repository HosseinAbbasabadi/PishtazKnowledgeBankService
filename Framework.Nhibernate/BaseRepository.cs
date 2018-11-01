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
        public readonly ISession Session;

        public BaseRepository(ISession session)
        {
            Session = session;
        }

        public void Create(T aggregate)
        {
            Session.Save(aggregate);
        }

        public void Update(T aggregate)
        {
            Session.Update(aggregate);
        }

        public void Delete(T aggregate)
        {
            Session.Delete(aggregate);
        }

        public void Evict(T aggregate)
        {
            Session.Evict(aggregate);
        }

        public T Get(TKey id)
        {
            return Session.Get<T>(id);
        }

        public List<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Session.Query<T>().Where(predicate).ToList();
        }

        public List<T> GetAll()
        {
            return Session.Query<T>().ToList();
        }

        public long GetNextId(string sequenceName)
        {
            return Session.GetNextSequence(sequenceName);
        }
    }
}