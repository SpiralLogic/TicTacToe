namespace TicTacToe.GameStatus
{
    public class GameWon : AbstractGameStatus
    {
        public GameWon(Player player) : base(player)
        {
        }

        public string Status => $"Well done {Player} you've won the game.";
    }
}