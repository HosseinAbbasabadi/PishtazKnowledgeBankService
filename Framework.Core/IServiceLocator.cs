namespace Framework.Core
{
    public interface IServiceLocator
    {
        T Resolve<T>();
        void Release(object obj);
    }
}