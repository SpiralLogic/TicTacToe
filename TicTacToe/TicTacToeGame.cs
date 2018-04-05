using System.Collections.Generic;
using TicTacToe.GameState;
using TicTacToe.TurnStatus;
using TicTacToe.WinConditions;
using Coordinate = System.Drawing.Point;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private readonly Board _board;
        private readonly Player _player1;
        private readonly Player _player2;
        private int _numberOfTurns;
        private HashSet<IWinCondition> _winConditions;

        public TicTacToeGame(int boardSize = 3)
        {
            AddWinConditions();

            _board = new Board(boardSize);
            _player1 = new Player("Player 1", 'X');
            _player2 = new Player("Player 2", 'O');
            CurrentPlayer = _player1;
            GameState = new GameInProgress(CurrentPlayer);
        }

        public Player CurrentPlayer { get; private set; }
        public IGameState GameState { get; private set; }

        public IEnumerable<char> DescribeBoard()
        {
            return _board.ToString();
        }

        public ITurnStatus TakeTurn(Coordinate coordinate)
        {
            if (!_board.IsOnBoard(coordinate)) return new CoordinateInvalid();

            if (!_board.IsEmptyAt(coordinate)) return new CoordinateAlreadyTaken();

            _board.SetPosition(coordinate, CurrentPlayer);

            UpdateGameState();

            return new TurnSuccess();
        }

        public void ForfeitGame()
        {
            GameState = new GameForfeit(CurrentPlayer);
        }

        private void UpdateGameState()
        {
            _numberOfTurns++;
            foreach (var winCondition in _winConditions)
                if (winCondition.HasWon(CurrentPlayer, _board))
                {
                    GameState = new GameWon(CurrentPlayer);
                    return;
                }

            if (_numberOfTurns == _board.Size * _board.Size)
            {
                GameState = new GameDraw();
                return;
            }

            SwitchPlayers();
            GameState = new GameInProgress(CurrentPlayer);
        }

        private void SwitchPlayers()
        {
            if (GameState is GameInProgress) CurrentPlayer = CurrentPlayer == _player1 ? _player2 : _player1;
        }

        private void AddWinConditions()
        {
            _winConditions = new HashSet<IWinCondition>
            {
                new HorizontalWinCondition(),
                new VerticalWinCondition(),
                new DiagonalWinCondition()
            };
        }
    }
}