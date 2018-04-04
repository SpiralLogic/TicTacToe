namespace TicTacToe.GameState
{
    public class GameWon : AbstractGameState
    {
        public GameWon(Player player) : base(player)
        {
        }

        public override string Status => $"Well done {Player.Name} you've won the game!";
    }
}