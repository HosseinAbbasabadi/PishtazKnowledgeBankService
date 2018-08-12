namespace Framework.Core.Events
{
    public static class Streamhelper
    {
        public static string StreamNameFor<T>(string id)
        {
            return $"{typeof(T).Name}-{id}";
        }
    }
}