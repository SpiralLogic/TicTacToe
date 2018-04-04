using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TicTacToe.GameStatus;
using TicTacToe.TurnStatus;
using TicTacToe.WinConditions;
using Coordinate = System.Drawing.Point;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private Board _board;
        private const int BoardSize = 3;
        private int _numberOfTurns = 0;
        private readonly Player _player1;
        private readonly Player _player2;
        private HashSet<IWinCondition> _winConditions;

        public TicTacToeGame()
        {
            AddWinConditions();

            _board = new Board(BoardSize);
            _player1 = new Player("Player 1", 'X');
            _player2 = new Player("Player 2", 'O');
            CurrentPlayer = _player1;
            GameStatus = new GameInProgress(CurrentPlayer);
        }

        private void AddWinConditions()
        {
            _winConditions = new HashSet<IWinCondition>
            {
                new HorizontalWinCondition(),
                new VerticalWinCondition(),
                new DiagonalWinCondition(),
            };
        }

        public Player CurrentPlayer { get; private set; }
        public IGameStatus GameStatus { get; private set; }
        public IEnumerable<char> DescribeBoard() => _board.ToString();

        public ITurnStatus TakeTurn(Coordinate coordinate)
        {
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
            _numberOfTurns++;
            foreach (var winCondition in _winConditions)
            {
                if (winCondition.HasWon(CurrentPlayer, _board))
                {
                    GameStatus = new GameWon(CurrentPlayer);
                    return;
                }
            }

            if (_numberOfTurns == _board.Size * _board.Size)
            {
                GameStatus = new GameDraw();
            }
        }

        private void SwitchPlayers()
        {
            if (GameStatus is GameInProgress)
            {
                CurrentPlayer = CurrentPlayer == _player1 ? _player2 : _player1;
            }
        }

        public IGameStatus ForfeitGame()
        {
            _board = new Board(BoardSize);

            return new GameForfeit(CurrentPlayer);
        }
    }
}