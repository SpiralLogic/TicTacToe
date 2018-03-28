namespace TicTacToe
{
    internal class Player
    {
        internal Player(string name, char symbol)
        {
            Name = name;
            Symbol= symbol;
        }
        
        internal string Name { get; }
        internal char Symbol { get; }
    }
}