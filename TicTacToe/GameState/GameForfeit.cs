namespace TicTacToe.GameState
{
    public class GameForfeit : AbstractGameState
    {
        public GameForfeit(Player player) : base(player)
        {
        }

        public override string Status => $"Well done {Player.Name} you forfeit the game!";
    }
}