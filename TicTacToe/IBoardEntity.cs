using System;

namespace TicTacToe
{
    public interface IBoardEntity: IEquatable<IBoardEntity>
    {
        char Symbol { get; }
    }
}