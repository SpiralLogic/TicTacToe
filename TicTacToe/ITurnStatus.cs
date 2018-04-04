namespace TicTacToe
{
    public interface ITurnStatus
    {
        string Status { get; }
    }

    public class TurnSuccess : ITurnStatus
    {
        public string Status => "Move Accepted!";
    }

    public class GameIsOver : ITurnStatus
    {
        public string Status => "Game has finished!";
    }

    public class CoordinateInvalid : ITurnStatus
    {
        public string Status => "Invalid move!";
    }

    public class CoordinateAlreadyTaken : ITurnStatus
    {
        public string Status => "Oh no, a piece is already at this place! Try again...";
    }
}