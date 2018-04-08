namespace TicTacToe
{
    public class Player : IBoardEntity
    {
        public string Name { get; }
        public char Symbol { get; }
        
        internal Player(string name, char symbol) 
        {
            Name = name;
            Symbol = symbol;
        }

    }
}