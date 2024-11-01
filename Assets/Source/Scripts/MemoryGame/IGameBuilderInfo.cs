using System;

public interface IGameBuilderInfo
{
    event Action Won;
    event Action Lost;
}