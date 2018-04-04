using System.Security.Cryptography.X509Certificates;
using Coordinate = System.Drawing.Point;

namespace TicTacToe
{
    internal class Board
    {
        private readonly Player[,] _board;
        private static readonly Player EmptyPosition = new Player("", '.');
        public int Size => _board.GetLength(0); 

        internal Board(int size)
        {
            _board = new Player[size, size];
            for (var row = 0; row < _board.GetLength(0); row++)
            {
                for (var cell = 0; cell < _board.GetLength(1); cell++)
                {
                    _board[row, cell] = EmptyPosition;
                }
            }
        }

        public void SetPosition(Coordinate coordinate, Player player)
        {
            _board[coordinate.X - 1, coordinate.Y - 1] = player;
        }

        public bool IsEmptyAt(Coordinate coordinate)
        {
            return _board[coordinate.X - 1, coordinate.Y - 1] == EmptyPosition;
        }

        public bool IsOnBoard(Coordinate coordinate)
        {
            return !(coordinate.X < 1 || coordinate.X > _board.GetLength(0) || coordinate.Y < 1 || coordinate.Y > _board.GetLength(0));
        }
        
        public Player GetPlayerAt(Coordinate coordinate)
        {
            return _board[coordinate.X, coordinate.Y];
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