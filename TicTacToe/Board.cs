using System;
using System.Linq;
using System.Runtime.Serialization;
using Coordinate = System.Drawing.Point;

namespace TicTacToe
{
    [DataContract]
    public class Board
    {
        [DataMember] private readonly IBoardEntity _emptyCoordinate;
        [DataMember] private readonly IBoardEntity[][] _board;

        public int BoardLength => _board.GetLength(0);

        public Board(int boardLength, IBoardEntity emptyBoardEntity = null)
        {
            if (boardLength < 3) throw new ArgumentOutOfRangeException(nameof(boardLength));

            _board = new IBoardEntity[boardLength][];
            _emptyCoordinate = emptyBoardEntity ?? new EmptyCoordinate('·');

            for (var row = 0; row < boardLength; row++)
            {
                _board[row] = new IBoardEntity[boardLength];
                for (var column = 0; column < boardLength; column++)
                {
                    _board[row][column] = _emptyCoordinate;
                }
            }
        }

        public void SetPosition(Coordinate coordinate, Player player)
        {
            _board[coordinate.X - 1][coordinate.Y - 1] = player;
        }

        public bool IsEmptyAt(Coordinate coordinate)
        {
            return _board[coordinate.X - 1][coordinate.Y - 1].Symbol == _emptyCoordinate.Symbol;
        }

        public bool IsOnBoard(Coordinate coordinate)
        {
            return coordinate.X >= 1 && coordinate.X <= BoardLength && coordinate.Y >= 1 && coordinate.Y <= BoardLength;
        }

        public bool IsFull()
        {
            return _board.SelectMany(b => b).All(coordinate => coordinate.Symbol != _emptyCoordinate.Symbol);
        }

        public IBoardEntity GetEntityAt(Coordinate coordinate)
        {
            return _board[coordinate.X - 1][coordinate.Y - 1];
        }

        public override string ToString()
        {
            var output = string.Empty;
            for (var row = 0; row < BoardLength; row++)
            {
                for (var column = 0; column < BoardLength; column++)
                {
                    output += _board[row][column].Symbol + " ";
                }

                output = output.TrimEnd() + '\n';
            }

            return output.TrimEnd();
        }
    }
}