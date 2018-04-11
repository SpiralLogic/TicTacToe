using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using TicTacToe.GameState;
using TicTacToe.TurnStatus;
using TicTacToe.WinConditions;
using Coordinate = System.Drawing.Point;

namespace TicTacToe
{
    [DataContract]  
    public class TicTacToeGame
    {
        [DataMember]  
        private readonly Player _player1;
        [DataMember]  
        private readonly Player _player2;
        [DataMember]  
        public Player CurrentPlayer { get; private set; }
        [DataMember]  
        public IGameState GameState { get; private set; }
        [DataMember]  
        private readonly Board _board;
        
        private IEnumerable<IWinCondition> WinConditions => AddWinConditions();

        public TicTacToeGame(int size, Player player1, Player player2)
        {
            AddWinConditions();

            _board = new Board(size);
            _player1 = player1;
            _player2 = player2;
            CurrentPlayer = _player1;
            GameState = new GameInProgress(CurrentPlayer);
        }

        public ITurnStatus TakeTurn(Coordinate coordinate)
        {
            if (!(GameState is GameInProgress))
            {
                return new TurnGameOver();
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

            UpdateGameState();

            return new TurnSuccess();
        }

        public void ForfeitGame()
        {
            GameState = new GameForfeit(CurrentPlayer);
        }

        public string DescribeBoard()
        {
            return _board.ToString();
        }
        
        private void UpdateGameState()
        {
            if (IsGameWon())
            {
                GameState = new GameWon(CurrentPlayer);
                return;
            }

            if (_board.IsFull())
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
            return WinConditions.Any(wc => wc.HasWon(CurrentPlayer, _board));
        }

        private void SwitchPlayers()
        {
            CurrentPlayer = Equals(CurrentPlayer, _player1) ? _player2 : _player1;
        }

        private static ISet<IWinCondition> AddWinConditions()
        {
            return new HashSet<IWinCondition>
            {
                new HorizontalWinCondition(),
                new VerticalWinCondition(),
                new DiagonalWinCondition()
            };
        }
    }
}