using System.Runtime.Serialization;

namespace TicTacToe
{
    [DataContract]  
    public class Player : IBoardEntity
    {
        [DataMember]  
        public string Name { get; private set; }
     
        [DataMember]  
        public char Symbol { get; private set; }
        
        public Player(string name, char symbol) 
        {
            Name = name;
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
            return obj.GetType() == GetType() && Equals((Player) obj);
        }

        public override int GetHashCode()
        {
            return Symbol.GetHashCode();
        }
    }
}