using Coordinate = System.Drawing.Point;

namespace TicTacToe
{
    internal class Board
    {
        private readonly IBoardEntity _emptyPosition;
        private readonly IBoardEntity[,] _board;

        internal Board(int size, IBoardEntity emptyBoardPEntity = null)
        {
            _board = new IBoardEntity[size, size];
            _emptyPosition = emptyBoardPEntity ?? new EmptyPosition('.');
            for (var row = 0; row < _board.GetLength(0); row++)
            {
                for (var cell = 0; cell < _board.GetLength(1); cell++)
                {
                    _board[row, cell] = _emptyPosition;
                }
            }
        }

        public int Size => _board.GetLength(0);

        public void SetPosition(Coordinate coordinate, Player player)
        {
            _board[coordinate.X - 1, coordinate.Y - 1] = player;
        }

        public bool IsEmptyAt(Coordinate coordinate)
        {
            return _board[coordinate.X - 1, coordinate.Y - 1] == _emptyPosition;
        }

        public bool IsOnBoard(Coordinate coordinate)
        {
            return !(coordinate.X < 1 || coordinate.X > _board.GetLength(0) || coordinate.Y < 1 || coordinate.Y > _board.GetLength(0));
        }

        public IBoardEntity GetEntityAt(Coordinate coordinate)
        {
            return _board[coordinate.X - 1, coordinate.Y - 1];
        }

        public override string ToString()
        {
            var output = string.Empty;
            for (var row = 0; row < _board.GetLength(0); row++)
            {
                for (var cell = 0; cell < _board.GetLength(1); cell++) output += _board[row, cell].Symbol + " ";

                output = output.TrimEnd() + '\n';
            }

            return output.TrimEnd();
        }
    }
}