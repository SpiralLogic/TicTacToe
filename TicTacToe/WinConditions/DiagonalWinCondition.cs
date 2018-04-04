using Coordinate = System.Drawing.Point;

namespace TicTacToe.WinConditions
{
    internal class DiagonalWinCondition : IWinCondition
    {
        public bool HasWon(Player player, Board board)
        {
            var hasWon = true;
            var hasWon2 = true;
            for (var i = 1; i <= board.Size; i++)
            {
                hasWon &= player == board.GetPlayerAt(new Coordinate(i, i));
                hasWon2 &= player == board.GetPlayerAt(new Coordinate(i, 4 - i));
            }

            return hasWon || hasWon2;
        }
    }
}