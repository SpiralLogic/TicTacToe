namespace TicTacToe.GameState
{
    public class GameWon : AbstractGameState
    {
        public GameWon(Player player) : base(player)
        {
        }

        public string Status => $"Well done {Player} you've won the game.";
    }
}