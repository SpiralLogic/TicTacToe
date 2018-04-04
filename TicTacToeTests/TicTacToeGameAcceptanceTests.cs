using TicTacToe;
using TicTacToe.GameStatus;
using TicTacToe.TurnStatus;
using Xunit;
using Coordinate = System.Drawing.Point;

namespace TicTacToeTests
{
    public class TicTacToeGameAcceptanceTests
    {
        [Fact]
        public void Player1CanWinTheGame()
        {
            string[] initalBoardExpected =
            {
                ". . .",
                ". . .",
                ". . ."
            };

            string[] firstMoveExpected =
            {
                "X . .",
                ". . .",
                ". . ."
            };

            string[] secondMoveExpected =
            {
                "X . .",
                ". . .",
                ". . O"
            };

            string[] thirdMoveExpected =
            {
                "X . .",
                ". . .",
                "X . O"
            };

            string[] fourthMoveExpected =
            {
                "X . .",
                "O . .",
                "X . O"
            };

            string[] fifthMoveExpected =
            {
                "X . X",
                "O . .",
                "X . O"
            };

            string[] sixthMoveExpected =
            {
                "X . X",
                "O . .",
                "X . O"
            };
            string[] seventhMoveExpected =
            {
                "X . X",
                "O X .",
                "X . O"
            };

            var game = new TicTacToeGame();
            Assert.Equal(string.Join('\n', initalBoardExpected), game.DescribeBoard());

            game.TakeTurn(new Coordinate(1, 1));
            Assert.Equal(string.Join('\n', firstMoveExpected), game.DescribeBoard());

            game.TakeTurn(new Coordinate(3, 3));
            Assert.Equal(string.Join('\n', secondMoveExpected), game.DescribeBoard());

            game.TakeTurn(new Coordinate(3, 1));
            Assert.Equal(string.Join('\n', thirdMoveExpected), game.DescribeBoard());

            game.TakeTurn(new Coordinate(2, 1));
            Assert.Equal(string.Join('\n', fourthMoveExpected), game.DescribeBoard());

            game.TakeTurn(new Coordinate(1, 3));
            Assert.Equal(string.Join('\n', fifthMoveExpected), game.DescribeBoard());

            game.TakeTurn(new Coordinate(2, 2));
            Assert.Equal(string.Join('\n', sixthMoveExpected), game.DescribeBoard());

            Assert.IsType<TurnSuccess>(game.TakeTurn(new Coordinate(1, 2)));
            Assert.IsType<GameWon>(game.GameStatus);
            Assert.Equal(string.Join('\n', seventhMoveExpected), game.DescribeBoard());
        }

        [Fact]
        public void Player2CanWinTheGame()
        {
            string[] initalBoardExpected =
            {
                ". . .",
                ". . .",
                ". . ."
            };

            string[] expectedState2 =
            {
                "X . .",
                ". . .",
                ". . ."
            };

            string[] expectedState3 =
            {
                "X . .",
                ". . .",
                ". . O"
            };

            string[] expectedState4 =
            {
                "X . .",
                ". . .",
                "X . O"
            };

            string[] expectedState5 =
            {
                "X . .",
                ". . O",
                "X . O"
            };
            
            string[] expectedState6 =
            {
                "X . .",
                ". X O",
                "X . O"
            };
            
            string[] expectedState7 =
            {
                "X . O",
                ". . O",
                "X . O"
            };

            var game = new TicTacToeGame();
            Assert.Equal(string.Join('\n', initalBoardExpected), game.DescribeBoard());

            game.TakeTurn(new Coordinate(1, 1));
            Assert.Equal(string.Join('\n', expectedState2), game.DescribeBoard());

            game.TakeTurn(new Coordinate(3, 3));
            Assert.Equal(string.Join('\n', expectedState3), game.DescribeBoard());

            game.TakeTurn(new Coordinate(3, 1));
            Assert.Equal(string.Join('\n', expectedState4), game.DescribeBoard());

            game.TakeTurn(new Coordinate(2, 3));
            Assert.Equal(string.Join('\n', expectedState5), game.DescribeBoard());

            game.TakeTurn(new Coordinate(2, 2));
            Assert.Equal(string.Join('\n', expectedState6), game.DescribeBoard());

            Assert.IsType<TurnSuccess>(game.TakeTurn(new Coordinate(1, 3)));
            Assert.IsType<GameWon>(game.GameStatus);
            Assert.Equal(string.Join('\n', expectedState7), game.DescribeBoard());
        }

        [Fact]
        public void GameCanBeADraw()
        {
            string[] initalBoardExpected =
            {
                ". . .",
                ". . .",
                ". . ."
            };

            string[] expectedState2 =
            {
                ". . .",
                ". X .",
                ". . ."
            };

            string[] expectedState3 =
            {
                ". . .",
                ". X .",
                ". . O"
            };

            string[] expectedState4 =
            {
                ". . .",
                ". X X",
                ". . O"
            };

            string[] expectedState5 =
            {
                ". . .",
                ". X X",
                ". O O"
            };

            string[] expectedState6 =
            {
                ". X .",
                ". X X",
                ". O O"
            };


            string[] expectedState7 =
            {
                ". X .",
                "O X X",
                ". O O"
            };


            string[] expectedState8 =
            {
                "X X .",
                "O X X",
                ". O O"
            };

            string[] expectedState9 =
            {
                "X X O",
                "O X X",
                ". O O"
            };
            string[] expectedState10 =
            {
                "X X O",
                "O X X",
                "X O O"
            };

            var game = new TicTacToeGame();
            Assert.Equal(string.Join('\n', initalBoardExpected), game.DescribeBoard());

            game.TakeTurn(new Coordinate(2, 2));
            Assert.Equal(string.Join('\n', expectedState2), game.DescribeBoard());

            game.TakeTurn(new Coordinate(3, 3));
            Assert.Equal(string.Join('\n', expectedState3), game.DescribeBoard());

            game.TakeTurn(new Coordinate(2, 3));
            Assert.Equal(string.Join('\n', expectedState4), game.DescribeBoard());

            game.TakeTurn(new Coordinate(3, 2));
            Assert.Equal(string.Join('\n', expectedState5), game.DescribeBoard());

            game.TakeTurn(new Coordinate(1, 2));
            Assert.Equal(string.Join('\n', expectedState6), game.DescribeBoard());

            game.TakeTurn(new Coordinate(2, 1));
            Assert.Equal(string.Join('\n', expectedState7), game.DescribeBoard());

            game.TakeTurn(new Coordinate(1, 1));
            Assert.Equal(string.Join('\n', expectedState8), game.DescribeBoard());

            game.TakeTurn(new Coordinate(1, 3));
            Assert.Equal(string.Join('\n', expectedState9), game.DescribeBoard());

            Assert.IsType<TurnSuccess>(game.TakeTurn(new Coordinate(3, 1)));
            Assert.IsType<GameDraw>(game.GameStatus);
            Assert.Equal(string.Join('\n', expectedState10), game.DescribeBoard());
        }
    }
}