namespace TicTacToe
{
    internal class EmptyPosition : IBoardEntity
    {
        public char Symbol { get; }

        internal EmptyPosition(char symbol)
        {
            Symbol = symbol;
        }
    }
}