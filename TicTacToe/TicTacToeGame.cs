using System;
using System.Collections.Generic;
using System.Drawing;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private const int BoardSize = 3;
        private readonly Board _board;
        private Player _player1;
        private Player _player2;
        private Player _currentPlayer;

        public TicTacToeGame()
        {
            _board = new Board(BoardSize);
            _player1 = new Player("Player 1", 'X');
            _player2 = new Player("Player 2", 'O');
            _currentPlayer = _player1;
        }

        public string MakeMove(Point position)
        {
            if (IsValidBoardPosition(position))
            {
                return $"Invalid move! Here's the current board:\n{_board}\n{_currentPlayer.Name} enter a coord x,y to place your {_currentPlayer.Symbol} or enter 'q' to give up: {position.X},{position.Y}";
            }

            if (!_board.IsPositionEmpty(position))
            {
                return "Oh no, a piece is already at this place! Try again...";
            }

            _board.SetPosition(position, 'X');
            SwitchPlayers();
            
            return $"Move accepted, here's the current board:\n{_board}\n{_currentPlayer.Name} enter a coord x,y to place your {_currentPlayer.Symbol} or enter 'q' to give up: {position.X},{position.Y}";
        }

        private void SwitchPlayers()
        {
            _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
        }

        public IEnumerable<char> NewGame()
        {
            return $"Here's the current board:\n{_board}\nPlayer 1 enter a coord x,y to place your X or enter 'q' to give up";
        }

        public string MakeMove(char move)
        {
            if (move == 'q')
            {
                return $"Invalid move! Here's the current board:\n{_board}\n{_currentPlayer.Name} enter a coord x,y to place your {_currentPlayer.Symbol} or enter 'q' to give up: {move}";
            }

            throw new ArgumentException("Invalid Move");
        }

        private static bool IsValidBoardPosition(Point position)
        {
            return position.X < 1 || position.X > BoardSize || position.Y < 1 || position.Y > BoardSize;
        }
    }
}