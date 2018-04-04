
namespace TicTacToe.WinConditions
{
    internal interface IWinCondition
    {
        bool HasWon(Player player, Board board);
    }
}