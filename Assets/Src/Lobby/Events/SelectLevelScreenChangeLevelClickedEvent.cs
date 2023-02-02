using Src.Common.Dispatcher;

namespace Src.Lobby.Events
{
    public struct SelectLevelScreenChangeLevelClickedEvent : IDispatcherEvent
    {
        public readonly int Direction;

        public SelectLevelScreenChangeLevelClickedEvent(int direction)
        {
            Direction = direction;
        }
    }
}