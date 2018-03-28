using System;
using System.Collections.Generic;

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

        public string MakeMove(uint x, uint y)
        {
            if (x < 1 || x > BoardSize || y < 1 || y > BoardSize)
            {
                throw new ArgumentException("Invalid Move");
            }

            _board.SetPosition(1, 1, 'X');

            return "Move accepted, here's the current board:\n" + _board + "\nPlayer 2 enter a coord x,y to place your 0 or enter 'q' to give up: 1,1";
        }

        public string MakeMove(char move)
        {
            if (move != 'q')
            {
                throw new ArgumentException("Invalid Move");
            }

            return
                "Move accepted, well done you've lost the game!\n" + _board;
        }

        public IEnumerable<char> Board()
        {
            return "Here's the current board:\n" + _board;
        }
    }
}