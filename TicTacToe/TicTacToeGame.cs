using System;
using System.Collections.Generic;
using System.Drawing;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private const int BoardSize = 3;
        private readonly Board _board;

        public TicTacToeGame()
        {
            _board = new Board(BoardSize);
        }

        public string MakeMove(Point position)
        {
            if (IsValidBoardPosition(position))
            {
                throw new ArgumentException("Invalid Move");
            }

            if (!_board.IsPositionEmpty(position))
            {
                return "Oh no, a piece is already at this place! Try again...";
            }

            _board.SetPosition(position, 'X');

            return $"Move accepted, here's the current board:\n{_board}\nPlayer 2 enter a coord x,y to place your 0 or enter 'q' to give up: {position.X},{position.Y}";
        }

        public IEnumerable<char> NewGame()
        {
            return $"Here's the current board:\n{_board}\nPlayer 1 enter a coord x,y to place your X or enter 'q' to give up";
        }

        public string MakeMove(char move)
        {
            if (move == 'q')
            {
                return "Move accepted, well done you've lost the game!\n" + _board;
            }

            throw new ArgumentException("Invalid Move");
        }

        private static bool IsValidBoardPosition(Point position)
        {
            return position.X < 1 || position.X > BoardSize || position.Y < 1 || position.Y > BoardSize;
        }
    }
}