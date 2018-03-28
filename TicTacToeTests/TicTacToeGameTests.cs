using System;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class TicTacToeGameTests
    {
        [Fact]
        public void InitialGameHasEmptyBoard()
        {
            var ttt = new TicTacToeGame();

            Assert.Equal("Here's the current board:\n. . .\n. . .\n. . .", ttt.Board());
        }

        [Fact]
        public void Entering11PlacesXInTopRight()
        {
            var ttt = new TicTacToeGame();
            const string expected = "Move accepted, here's the current board:\n" +
                                    "X . .\n" +
                                    ". . .\n" +
                                    ". . .\n" +
                                    "Player 2 enter a coord x,y to place your 0 or enter 'q' to give up: 1,1";
            
            Assert.Equal(expected, ttt.MakeMove(1, 1));
        }
        [Fact]
        public void EnteringQGivesUp()
        {
            var ttt = new TicTacToeGame();
            const string expected = "Move accepted, well done you've lost the game!\n" +
                                    ". . .\n" +
                                    ". . .\n" +
                                    ". . .";

            Assert.Equal(expected, ttt.MakeMove('q'));
        }
    }
}