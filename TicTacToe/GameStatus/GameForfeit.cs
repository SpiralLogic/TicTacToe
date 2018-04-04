namespace TicTacToe.GameStatus
{
    public class GameForfeit : AbstractGameStatus
    {
        public GameForfeit(Player player) : base(player)
        {
        }

        public string Status => $"Well done {Player} you've forfeited the game game!";
    }
}