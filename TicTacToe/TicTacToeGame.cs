using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Coordinate = System.Drawing.Point;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private Board _board;
        private const int BoardSize = 3;
        private readonly Player _player1;
        private readonly Player _player2;

        public TicTacToeGame()
        {
            _board = new Board(BoardSize);
            _player1 = new Player("Player 1", 'X');
            _player2 = new Player("Player 2", 'O');
            CurrentPlayer = _player1;
            GameStatus = new GameInProgress(CurrentPlayer);
        }

        public Player CurrentPlayer { get; private set; }
        public IGameStatus GameStatus { get; private set; }
        public IEnumerable<char> DescribeBoard() => _board.ToString();

        public ITurnStatus TakeTurn(Coordinate coordinate)
        {
            if (!(GameStatus is GameInProgress))
            {
                return new GameIsOver();
            }

            if (!_board.IsOnBoard(coordinate))
            {
                return new CoordinateInvalid();
            }

            if (!_board.IsEmptyAt(coordinate))
            {
                return new CoordinateAlreadyTaken();
            }

            _board.SetPosition(coordinate, CurrentPlayer);

            UpdateGameStatus();
            SwitchPlayers();

            return new TurnSuccess();
        }

        private void UpdateGameStatus()
        {
            if (IsHorizontalWin())
            {
                GameStatus = new GameWon(CurrentPlayer);
            }
        }

        private bool IsHorizontalWin()
        {
            var win = new HorizontalWinCondition();
            return win.HasWon(CurrentPlayer, _board);
        }

        private void SwitchPlayers()
        {
            CurrentPlayer = CurrentPlayer == _player1 ? _player2 : _player1;
        }

        public IGameStatus ForfeitGame()
        {
            _board = new Board(BoardSize);

            return new GameForfeit(CurrentPlayer);
        }
    }
}