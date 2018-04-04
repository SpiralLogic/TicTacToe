namespace TicTacToe.GameState
{
    public interface IGameState
    {
        string Status { get; }
    }

    public abstract class AbstractGameState : IGameState
    {
        public abstract string Status { get; }
        protected readonly Player Player;

        internal AbstractGameState(Player player)
        {
            Player = player;
        }
    }
}