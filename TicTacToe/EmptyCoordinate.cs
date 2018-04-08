namespace TicTacToe
{
    internal class EmptyCoordinate : IBoardEntity
    {
        public char Symbol { get; }

        internal EmptyCoordinate(char symbol)
        {
            Symbol = symbol;
        }
    }
}