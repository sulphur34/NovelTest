using System;

namespace MemoryGame
{
    public interface IGameBuilderInfo
    {
        event Action Won;
        event Action Lost;
    }
}