using Coordinate = System.Drawing.Point;

namespace TicTacToe.WinConditions
{
    internal class HorizontalWinCondition : IWinCondition
    {
        public bool HasWon(Player player, Board board)
        {
            for (var x = 1; x <= board.Size; x++)
            {
                var hasWon = true;
                for (var y = 1; y <= board.Size; y++)
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