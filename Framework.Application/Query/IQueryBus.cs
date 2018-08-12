namespace Framework.Application.Query
{
    public interface IQueryBus
    {
        T Dispatch<T>(); //where T : IQuery;
        T Dispatch<T, TU>(TU condition); //where T : IQuery;
    }
}
