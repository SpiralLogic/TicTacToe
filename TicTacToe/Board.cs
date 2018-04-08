using System.Linq;
using Coordinate = System.Drawing.Point;

namespace TicTacToe
{
    internal class Board
    {
        private readonly IBoardEntity _emptyCoordinate;
        private readonly IBoardEntity[,] _board;

        public int Size => _board.GetLength(0);

        internal Board(int size, IBoardEntity emptyBoardEntity = null)
        {
            _board = new IBoardEntity[size, size];
            _emptyCoordinate = emptyBoardEntity ?? new EmptyCoordinate('.');

            for (var row = 0; row < _board.GetLength(0); row++)
            {
                for (var cell = 0; cell < _board.GetLength(1); cell++)
                {
                    _board[row, cell] = _emptyCoordinate;
                }
            }
        }

        public void SetPosition(Coordinate coordinate, Player player)
        {
            _board[coordinate.X - 1, coordinate.Y - 1] = player;
        }

        public bool IsEmptyAt(Coordinate coordinate)
        {
            return _board[coordinate.X - 1, coordinate.Y - 1] == _emptyCoordinate;
        }

        public bool IsOnBoard(Coordinate coordinate)
        {
            return coordinate.X >= 1 && coordinate.X <= _board.GetLength(0) && coordinate.Y >= 1 && coordinate.Y <= _board.GetLength(0);
        }

        public bool IsFull()
        {
            return _board.Cast<IBoardEntity>().All(coordinate => coordinate != _emptyCoordinate);
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
                for (var cell = 0; cell < _board.GetLength(1); cell++)
                {
                    output += _board[row, cell].Symbol + " ";
                }

                output = output.TrimEnd() + '\n';
            }

            return output.TrimEnd();
        }
    }
}