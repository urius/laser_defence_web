using SimpleDI;
using Src.Common.Dispatcher;

namespace Src.Common.Commands
{
    public class EventCommandMapper
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IEventListener _eventListener;

        public EventCommandMapper()
        {
            _eventListener = Resolver.Resolve<IEventListener>();
            _commandExecutor = Resolver.Resolve<ICommandExecutor>();
        }

        public void Map<TEvent, TCommand>()
            where TEvent : IDispatcherEvent
            where TCommand : IAsyncCommand<TEvent>, new()
        {
            _eventListener.Subscribe<TEvent>(ExecuteEventCommandAction<TEvent, TCommand>);
        }

        public void MapToNoParametersCommand<TEvent, TCommand>()
            where TEvent : IDispatcherEvent
            where TCommand : IAsyncCommand, new()
        {
            _eventListener.Subscribe<TEvent>(ExecuteEventCommandActionNoParams<TEvent, TCommand>);
        }

        public void Unmap<TEvent, TCommand>()
            where TEvent : IDispatcherEvent
            where TCommand : IAsyncCommand<TEvent>, new()
        {
            _eventListener.Unsubscribe<TEvent>(ExecuteEventCommandAction<TEvent, TCommand>);
        }


        public void UnmapFromNoParametersCommand<TEvent, TCommand>()
            where TEvent : IDispatcherEvent
            where TCommand : IAsyncCommand, new()
        {
            _eventListener.Unsubscribe<TEvent>(ExecuteEventCommandActionNoParams<TEvent, TCommand>);
        }

        private void ExecuteEventCommandAction<TEvent, TCommand>(TEvent @event)
            where TCommand : IAsyncCommand<TEvent>, new()
        {
            _commandExecutor.ExecuteAsync<TCommand, TEvent>(@event);
        }

        private void ExecuteEventCommandActionNoParams<TEvent, TCommand>(TEvent @event)
            where TCommand : IAsyncCommand, new()
        {
            _commandExecutor.ExecuteAsync<TCommand>();
        }
    }

    public static class EventCommandMapperExtensions
    {
        public static void Map<TEvent, TCommand>(this EventCommandMapper mapper)
            where TEvent : IDispatcherEvent
            where TCommand : IAsyncCommand, new()
        {
            mapper.MapToNoParametersCommand<TEvent, TCommand>();
        }

        public static void Unmap<TEvent, TCommand>(this EventCommandMapper mapper)
            where TEvent : IDispatcherEvent
            where TCommand : IAsyncCommand, new()
        {
            mapper.UnmapFromNoParametersCommand<TEvent, TCommand>();
        }
    }
}