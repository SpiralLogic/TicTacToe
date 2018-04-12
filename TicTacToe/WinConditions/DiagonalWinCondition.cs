using Coordinate = System.Drawing.Point;

namespace TicTacToe.WinConditions
{
    internal class DiagonalWinCondition : IWinCondition
    {
        public bool HasWon(Player player, Board board)
        {
            var hasWonLeftRoRight = true;
            var hasWonRightToLeft = true;

            for (var i = 1; i <= board.BoardLength; i++)
            {
                hasWonLeftRoRight &= Equals(player, board.GetEntityAt(new Coordinate(i, i)));
                hasWonRightToLeft &= Equals(player, board.GetEntityAt(new Coordinate(i, board.BoardLength + 1 - i)));
            }

            return hasWonLeftRoRight || hasWonRightToLeft;
        }
    }
}