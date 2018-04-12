﻿using System.Collections.Generic;
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
        [DataMember] private readonly Board _board;

        [DataMember]
        public Player Player1 { get; private set; }

        [DataMember]
        public Player Player2 { get; private set; }

        [DataMember]
        public Player CurrentPlayer { get; private set; }

        [DataMember]
        public IGameState GameState { get; private set; }

        private IEnumerable<IWinCondition> _winConditions;

        public TicTacToeGame(int boardLength, Player player1 = null, Player player2 = null)
        {
            _winConditions = CreateWinConditions();

            _board = new Board(boardLength);
            Player1 = player1 ?? new Player("Player 1", 'X');
            Player2 = player2 ?? new Player("Player 2", 'O');
            CurrentPlayer = Player1;
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
            if ((GameState is GameInProgress))
            {
                GameState = new GameForfeit(CurrentPlayer);
            }
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
            return _winConditions.Any(wc => wc.HasWon(CurrentPlayer, _board));
        }

        private void SwitchPlayers()
        {
            CurrentPlayer = Equals(CurrentPlayer, Player1) ? Player2 : Player1;
        }

        private IEnumerable<IWinCondition> CreateWinConditions()
        {
            return new HashSet<IWinCondition>
            {
                new HorizontalWinCondition(),
                new VerticalWinCondition(),
                new DiagonalWinCondition()
            };
        }

        [OnDeserializing]
        private void OnDeserialize(StreamingContext ctx)
        {
            _winConditions = CreateWinConditions();
        }
    }
}