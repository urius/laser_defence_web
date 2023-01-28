using System;

namespace Src.Common.Dispatcher
{
    internal static class SubscriptionData<T> where T : IDispatcherEvent
    {
        public static Action<T> Action;
    }
}