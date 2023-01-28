using System;

namespace Src.Common.Dispatcher
{
    public class EventDispatcher : IEventDispatcher
    {
        public void Dispatch<T>(T @event) where T : IDispatcherEvent
        {
            SubscriptionData<T>.Action?.Invoke(@event);
        }

        public void Subscribe<T>(Action<T> subscribeAction) where T : IDispatcherEvent
        {
            SubscriptionData<T>.Action += subscribeAction;
        }

        public void Unsubscribe<T>(Action<T> subscribeAction) where T : IDispatcherEvent
        {
            SubscriptionData<T>.Action -= subscribeAction;
        }

        public void UnsubscribeAll<T>() where T : IDispatcherEvent
        {
            SubscriptionData<T>.Action = null;
        }
    }
}