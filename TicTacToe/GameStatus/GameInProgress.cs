namespace TicTacToe.GameStatus
{
    public class GameInProgress : AbstractGameStatus
    {
        public GameInProgress(Player player) : base(player)
        {
        }

        public string Status => $"{Player.Name} enter a coord x,y to place your {Player.Symbol} or enter 'q' to give up";
    }
}