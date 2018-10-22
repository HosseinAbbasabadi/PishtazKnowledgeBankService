namespace Framework.Core
{
    public static class ServiceLocator
    {
        public static IServiceLocator Current { get; private set; }

        public static void SetCurrent(IServiceLocator item)
        {
            Current = item;
        }
    }
}