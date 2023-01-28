using System;

namespace Src.Common.Dispatcher
{
    public interface IEventListener
    {
        void Subscribe<T>(Action<T> subscribeAction) where T : IDispatcherEvent;
        void Unsubscribe<T>(Action<object> subscribeAction) where T : IDispatcherEvent;
        void UnsubscribeAll<T>() where T : IDispatcherEvent;
    }
}