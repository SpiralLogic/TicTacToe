using Coordinate = System.Drawing.Point;

namespace TicTacToe.WinConditions
{
    internal class HorizontalWinCondition : IWinCondition
    {
        public bool HasWon(Player player, Board board)
        {
            for (var row = 1; row <= board.Size; row++)
            {
                if (DoesPlayerFillRow(player, board, row)) return true;
            }

            return false;
        }

        private static bool DoesPlayerFillRow(Player player, Board board, int x)
        {
            for (var column = 1; column <= board.Size; column++)
            {
                if (!Equals(player, board.GetEntityAt(new Coordinate(x, column))))
                {
                    return false;
                }
            }

            return true;
        }
    }
}