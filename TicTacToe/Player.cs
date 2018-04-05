namespace TicTacToe
{
    public class Player : IBoardEntity
    {
        internal string Name { get; }
        public char Symbol { get; }
        
        internal Player(string name, char symbol) 
        {
            Name = name;
            Symbol = symbol;
        }

    }
}