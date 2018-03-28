namespace TicTacToe
{
    internal class Board
    {
        private readonly char[,] _board;
        private const char EmptyPoition = '.';

        internal Board(int size)
        {
            _board = new char[size, size];
            for (var row = 0; row < _board.GetLength(0); row++)
            {
                for (var cell = 0; cell < _board.GetLength(1); cell++)
                {
                    _board[row, cell] = EmptyPoition;
                }
            }
        }

        public override string ToString()
        {
               
            var output = string.Empty;
            for (var row = 0; row < _board.GetLength(0); row++)
            {
                for (var cell = 0; cell < _board.GetLength(1); cell++)
                {
                    output += _board[row,cell] + " ";
                }

                output = output.TrimEnd() + '\n';
            }

            return output.TrimEnd();
        }

        public void SetPosition(int x, int y, char piece)
        {
            _board[x - 1, y - 1] = piece;
        }
    }
}