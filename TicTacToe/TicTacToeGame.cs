using System.Collections.Generic;
using System.Linq;
using TicTacToe.GameState;
using TicTacToe.TurnStatus;
using TicTacToe.WinConditions;
using Coordinate = System.Drawing.Point;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private readonly Player _player1;
        private readonly Player _player2;
        private HashSet<IWinCondition> _winConditions;

        public Player CurrentPlayer { get; private set; }
        public IGameState GameState { get; private set; }
        public readonly Board Board;

        public TicTacToeGame(Board board, Player player1, Player player2)
        {
            AddWinConditions();

            Board = board;
            _player1 = player1;
            _player2 = player2;
            CurrentPlayer = _player1;
            GameState = new GameInProgress(CurrentPlayer);
        }

        public ITurnStatus TakeTurn(Coordinate coordinate)
        {
            if (!Board.IsOnBoard(coordinate))
            {
                return new CoordinateInvalid();
            }

            if (!Board.IsEmptyAt(coordinate))
            {
                return new CoordinateAlreadyTaken();
            }

            Board.SetPosition(coordinate, CurrentPlayer);

            UpdateGameState();

            return new TurnSuccess();
        }

        public void ForfeitGame()
        {
            GameState = new GameForfeit(CurrentPlayer);
        }

        private void UpdateGameState()
        {
            if (IsGameWon())
            {
                GameState = new GameWon(CurrentPlayer);
                return;
            }

            if (Board.IsFull())
            {
                GameState = new GameDraw();
                return;
            }

            if (GameState is GameInProgress)
            {
                SwitchPlayers();
            }

            GameState = new GameInProgress(CurrentPlayer);
        }

        private bool IsGameWon()
        {
            return _winConditions.Any(wc => wc.HasWon(CurrentPlayer, Board));
        }

        private void SwitchPlayers()
        {
            CurrentPlayer = CurrentPlayer == _player1 ? _player2 : _player1;
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