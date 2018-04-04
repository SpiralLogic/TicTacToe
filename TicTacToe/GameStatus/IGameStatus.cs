namespace TicTacToe.GameStatus
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
}