using Coordinate = System.Drawing.Point;

namespace TicTacToe.WinConditions
{
    internal class VerticalWinCondition : IWinCondition
    {
        public bool HasWon(Player player, Board board)
        {
            for (var row = 1; row <= board.Size; row++)
            {
                if (DoesPlayerFillColumn(player, board, row)) return true;
            }

            return false;
        }
        
        private static bool DoesPlayerFillColumn(Player player, Board board, int y)
        {
            for (var row = 1; row <= board.Size; row++)
            {
                if (!Equals(player, board.GetEntityAt(new Coordinate(row, y))))
                {
                    return false;
                }
            }

            return true;
        }
    }
}