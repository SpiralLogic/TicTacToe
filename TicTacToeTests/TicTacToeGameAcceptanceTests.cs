using TicTacToe;
using Xunit;
using Coordinate = System.Drawing.Point;

namespace TicTacToeTests
{
    public class TicTacToeGameAcceptanceTests
    {
        [Fact]
        public void GameCanBePlayedWithAWinner()
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
                "O O .",
                "X . O"
            };
            string[] seventhMoveExpected =
            {
                "X X X",
                "O O .",
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

            Assert.IsType<GameWon>(game.TakeTurn(new Coordinate(1, 2)));
            Assert.Equal(string.Join('\n', seventhMoveExpected), game.DescribeBoard());
        }
    }
}