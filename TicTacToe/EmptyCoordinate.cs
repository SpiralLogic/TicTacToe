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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EmptyCoordinate) obj);
        }

        public override int GetHashCode()
        {
            return Symbol.GetHashCode();
        }
    }
}