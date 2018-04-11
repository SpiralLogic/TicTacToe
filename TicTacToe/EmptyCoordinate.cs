using System.Runtime.Serialization;

namespace TicTacToe
{
    [DataContract]  
    public class EmptyCoordinate : IBoardEntity
    {
        [DataMember]  
        public char Symbol { get; protected set; }

        public EmptyCoordinate(char symbol)
        {
            Symbol = symbol;
        }

        public bool Equals(IBoardEntity other)
        {
            return Symbol == other.Symbol;
        }
    }
}