namespace TicTacToe
{
    public interface IGameStatus
    {
        string Status { get; }
    }

    public abstract class AbstractGameStatus : IGameStatus
    {
        public string Status { get; }
        protected readonly Player Player;

        internal AbstractGameStatus(Player player)
        {
            Player = player;
        }
    }

    public class GameInProgress : AbstractGameStatus
    {
        public GameInProgress(Player player) : base(player)
        {
        }

        public string Status => $"{Player.Name} enter a coord x,y to place your {Player.Symbol} or enter 'q' to give up";
    }

    public class GameWon : AbstractGameStatus
    {
        public GameWon(Player player) : base(player)
        {
        }

        public string Status => $"Well done {Player} you've won the game.";
    }

    public class GameForfeit : AbstractGameStatus
    {
        public GameForfeit(Player player) : base(player)
        {
        }

        public string Status => $"Well done {Player} you've forfeited the game game!";
    }
}