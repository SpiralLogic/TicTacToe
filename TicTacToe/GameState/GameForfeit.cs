namespace TicTacToe.GameState
{
    public class GameForfeit : AbstractGameState
    {
        public GameForfeit(Player player) : base(player)
        {
        }

        public override string Describe => $"Well done {Player.Name} you forfeit the game!";
    }
}