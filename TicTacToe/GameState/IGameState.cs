namespace TicTacToe.GameState
{
    public interface IGameState
    {
        string Describe { get; }
    }

    public abstract class AbstractGameState : IGameState
    {
        protected readonly Player Player;

        internal AbstractGameState(Player player)
        {
            Player = player;
        }

        public abstract string Describe { get; }
    }
}