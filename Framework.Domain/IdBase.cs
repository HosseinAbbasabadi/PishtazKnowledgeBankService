namespace Framework.Domain
{
    public class IdBase<T> : ValueObjectBase
    {
        public T DbId { get; private set; }

        protected IdBase(T idDbId)
        {
            DbId = idDbId;
        }

        public override int GetHashCode()
        {
            return DbId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj != null && GetType() != obj.GetType()) return false;
            return obj is IdBase<T> otherId && otherId.DbId.Equals(DbId);
        }
    }
}
