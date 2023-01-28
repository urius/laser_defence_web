namespace Src.Common.Dispatcher
{
    public interface IEventDispatcher
    {
        void Dispatch<T>(T @event) where T : IDispatcherEvent;
    }
}