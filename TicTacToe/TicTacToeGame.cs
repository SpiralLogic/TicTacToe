using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TicTacToe.GameState;
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

        public Player CurrentPlayer { get; private set; }
        public IGameState GameState { get; private set; }
        public IEnumerable<char> DescribeBoard() => _board.ToString();

        public TicTacToeGame()
        {
            AddWinConditions();

            _board = new Board(BoardSize);
            _player1 = new Player("Player 1", 'X');
            _player2 = new Player("Player 2", 'O');
            CurrentPlayer = _player1;
            GameState = new GameInProgress(CurrentPlayer);
        }

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
        
        public IGameState ForfeitGame()
        {
            _board = new Board(BoardSize);

            return new GameForfeit(CurrentPlayer);
        }
        
        private void UpdateGameStatus()
        {
            _numberOfTurns++;
            foreach (var winCondition in _winConditions)
            {
                if (winCondition.HasWon(CurrentPlayer, _board))
                {
                    GameState = new GameWon(CurrentPlayer);
                    return;
                }
            }

            if (_numberOfTurns == _board.Size * _board.Size)
            {
                GameState = new GameDraw();
            }
        }

        private void SwitchPlayers()
        {
            if (GameState is GameInProgress)
            {
                CurrentPlayer = CurrentPlayer == _player1 ? _player2 : _player1;
            }
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
    }
}