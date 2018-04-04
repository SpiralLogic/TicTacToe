namespace TicTacToe.TurnStatus
{
    public class CoordinateInvalid : ITurnStatus
    {
        public string Status => "Invalid move!";
    }
}