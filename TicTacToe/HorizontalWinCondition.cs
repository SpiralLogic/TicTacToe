using System.Drawing;

namespace TicTacToe
{
    internal class HorizontalWinCondition
    {
        internal bool HasWon(Player player, Board board)
        {
            var hasWon = true;
            for (var x = 0; x < board.Size; x++)
            {
                for (var y = 0; y < board.Size; y++)
                {
                    hasWon &= player == board.GetPlayerAt(new Point(x, y));
                    if (!hasWon) break;
                }

                if (hasWon) return true;
            }

            return false;
        }
    }
}