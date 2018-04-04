namespace TicTacToe.TurnStatus
{
    public class TurnSuccess : ITurnStatus
    {
        public string Status => "Move Accepted!";
    }
}