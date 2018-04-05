﻿using Coordinate = System.Drawing.Point;

namespace TicTacToe.WinConditions
{
    internal class VerticalWinCondition : IWinCondition
    {
        public bool HasWon(Player player, Board board)
        {
            for (var y = 1; y <= board.Size; y++)
            {
                var hasWon = true;
                for (var x = 1; x <= board.Size; x++)
                {
                    hasWon &= player == board.GetEntityAt(new Coordinate(x, y));
                    if (!hasWon) break;
                }

                if (hasWon) return true;
            }

            return false;
        }
    }
}