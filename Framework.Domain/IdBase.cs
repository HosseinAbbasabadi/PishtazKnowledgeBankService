namespace Framework.Domain
{
    public class IdBase<T> : ValueObjectBase
    {
        public T DbId { get; private set; }
        protected IdBase() { }
        protected IdBase(T idDbId)
        {
            DbId = idDbId;
        }
    }
}
