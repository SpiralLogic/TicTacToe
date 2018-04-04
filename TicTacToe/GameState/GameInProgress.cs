namespace TicTacToe.GameState
{
    public class GameInProgress : AbstractGameState
    {
        public GameInProgress(Player player) : base(player)
        {
        }

        public string Status => $"{Player.Name} enter a coord x,y to place your {Player.Symbol} or enter 'q' to give up";
    }
}