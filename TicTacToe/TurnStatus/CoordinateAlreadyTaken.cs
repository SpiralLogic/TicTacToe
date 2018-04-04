namespace TicTacToe.TurnStatus
{
    public class CoordinateAlreadyTaken : ITurnStatus
    {
        public string Status => "Oh no, a piece is already at this place! Try again...";
    }
}