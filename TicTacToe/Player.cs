namespace TicTacToe
{
    public class Player
    {
        internal Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        internal string Name { get; }
        public char Symbol { get; }
    }
}