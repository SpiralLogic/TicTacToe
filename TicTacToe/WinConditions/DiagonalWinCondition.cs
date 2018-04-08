using Coordinate = System.Drawing.Point;

namespace TicTacToe.WinConditions
{
    internal class DiagonalWinCondition : IWinCondition
    {
        public bool HasWon(Player player, Board board)
        {
            var hasWonLeftRoRight = true;
            var hasWonRightToLeft = true;
            
            for (var i = 1; i <= board.Size; i++)
            {
                hasWonLeftRoRight &= player == board.GetEntityAt(new Coordinate(i, i));
                hasWonRightToLeft &= player == board.GetEntityAt(new Coordinate(i, 4 - i));
            }

            return hasWonLeftRoRight || hasWonRightToLeft;
        }
    }
}