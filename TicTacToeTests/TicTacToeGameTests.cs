using System;
using System.Drawing;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class TicTacToeGameTests
    {
        [Fact]
        public void InitialGameHasEmptyBoard()
        {
            const string expected = "Here's the current board:\n" +
                                    ". . .\n" +
                                    ". . .\n" +
                                    ". . .\n" +
                                    "Player 1 enter a coord x,y to place your X or enter 'q' to give up";
            
            var ttt = new TicTacToeGame();

            Assert.Equal(expected, ttt.NewGame());
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

            Assert.Equal(expected, ttt.MakeMove(new Point(1,1)));
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

        [Fact]
        public void PlacingAPieceInAPositionAlreadyOccupiedGivesError()
        {
            var ttt = new TicTacToeGame();
            const string expected = "Oh no, a piece is already at this place! Try again...";

            ttt.MakeMove(new Point(1,1));
            Assert.Equal(expected, ttt.MakeMove(new Point(1,1)));
        }
    }
}
