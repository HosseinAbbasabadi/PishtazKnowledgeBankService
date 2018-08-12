namespace Framework.Application.Command
{
    public interface ICommandBus
    {
        void Dispatch<T>(T command);
    }
}