namespace TicTacToe.GameState
{
    public class GameForfeit : AbstractGameState
    {
        public GameForfeit(Player player) : base(player)
        {
        }

        public string Status => $"Well done {Player} you've forfeited the game game!";
    }
}