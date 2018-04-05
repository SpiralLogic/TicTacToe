using TicTacToe;
using TicTacToe.GameState;
using TicTacToe.TurnStatus;
using Xunit;
using Coordinate = System.Drawing.Point;

namespace TicTacToeTests
{
    public class TicTacToeGameTests
    {
        [Fact]
        public void EnteringInvalidMoveHasInvalidTurnStatus()
        {
            string[] expected =
            {
                ". . .",
                ". . .",
                ". . ."
            };

            var game = new TicTacToeGame();

            Assert.IsType<CoordinateInvalid>(game.TakeTurn(new Coordinate(0, 1)));
            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }

        [Fact]
        public void InitialGameHasEmptyBoard()
        {
            string[] expected =
            {
                ". . .",
                ". . .",
                ". . ."
            };

            var game = new TicTacToeGame();

            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }

        [Fact]
        public void PlacingAPieceInAPositionAlreadyOccupiedGivesError()
        {
            var game = new TicTacToeGame();

            game.TakeTurn(new Coordinate(1, 1));
            Assert.IsType<CoordinateAlreadyTaken>(game.TakeTurn(new Coordinate(1, 1)));
        }

        [Fact]
        public void TakingMultipleTurnsAlternatesPlayerSymbols()
        {
            string[] expected =
            {
                "X O X",
                "O X O",
                ". . ."
            };

            var game = new TicTacToeGame();

            var firstPlayer = game.CurrentPlayer;

            game.TakeTurn(new Coordinate(1, 1));
            var secondPlayer = game.CurrentPlayer;

            game.TakeTurn(new Coordinate(1, 2));
            game.TakeTurn(new Coordinate(1, 3));
            game.TakeTurn(new Coordinate(2, 1));
            game.TakeTurn(new Coordinate(2, 2));
            game.TakeTurn(new Coordinate(2, 3));

            Assert.Equal('X', firstPlayer.Symbol);
            Assert.Equal('O', secondPlayer.Symbol);
            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }

        [Fact]
        public void TakingValidTurnPlacesPlayerSymbolInCorrectPosition()
        {
            string[] before =
            {
                ". . .",
                ". . .",
                ". . ."
            };

            string[] expected =
            {
                "X . .",
                ". . .",
                ". . ."
            };

            var game = new TicTacToeGame();

            Assert.IsType<TurnSuccess>(game.TakeTurn(new Coordinate(1, 1)));
            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }

        [Fact]
        public void TheGameEndsIfAPlayerForfeits()
        {
            string[] expected =
            {
                ". . .",
                ". . .",
                ". . ."
            };

            var game = new TicTacToeGame();
            game.ForfeitGame();

            Assert.IsType<GameForfeit>(game.GameState);
            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }

        [Fact]
        public void TheGameIsWonWhenAPlayerTakesADiagonalLeftToRight()
        {
            string[] expected =
            {
                "O O X",
                ". X .",
                "X . ."
            };

            var game = new TicTacToeGame();

            game.TakeTurn(new Coordinate(3, 1));
            game.TakeTurn(new Coordinate(1, 1));
            game.TakeTurn(new Coordinate(2, 2));
            game.TakeTurn(new Coordinate(1, 2));

            var statusBeforeWinningTurn = game.GameState;
            game.TakeTurn(new Coordinate(1, 3));

            Assert.IsType<GameInProgress>(statusBeforeWinningTurn);
            Assert.Equal('X', game.CurrentPlayer.Symbol);
            Assert.IsType<GameWon>(game.GameState);
            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }

        [Fact]
        public void TheGameIsWonWhenAPlayerTakesADiagonalRightToLeft()
        {
            string[] expected =
            {
                "X O O",
                ". X .",
                ". . X"
            };

            var game = new TicTacToeGame();

            game.TakeTurn(new Coordinate(1, 1));
            game.TakeTurn(new Coordinate(1, 3));
            game.TakeTurn(new Coordinate(2, 2));
            game.TakeTurn(new Coordinate(1, 2));

            var statusBeforeWinningTurn = game.GameState;
            game.TakeTurn(new Coordinate(3, 3));

            Assert.IsType<GameInProgress>(statusBeforeWinningTurn);
            //Assert.Equal('X', game.CurrentPlayer.Symbol);
            Assert.IsType<GameWon>(game.GameState);
            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }

        [Fact]
        public void TheGameIsWonWhenAPlayerTakesAWholeColumn()
        {
            string[] expected =
            {
                "X O X",
                ". O .",
                "X O ."
            };

            var game = new TicTacToeGame();

            game.TakeTurn(new Coordinate(1, 1));
            game.TakeTurn(new Coordinate(1, 2));
            game.TakeTurn(new Coordinate(1, 3));
            game.TakeTurn(new Coordinate(2, 2));
            game.TakeTurn(new Coordinate(3, 1));

            var statusBeforeWinningTurn = game.GameState;
            game.TakeTurn(new Coordinate(3, 2));

            Assert.IsType<GameInProgress>(statusBeforeWinningTurn);
            Assert.Equal('O', game.CurrentPlayer.Symbol);
            Assert.IsType<GameWon>(game.GameState);
            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }

        [Fact]
        public void TheGameIsWonWhenAPlayerTakesAWholeRow()
        {
            string[] expected =
            {
                "X X X",
                ". . .",
                "O . O"
            };

            var game = new TicTacToeGame();

            game.TakeTurn(new Coordinate(1, 1));
            game.TakeTurn(new Coordinate(3, 1));
            game.TakeTurn(new Coordinate(1, 2));
            game.TakeTurn(new Coordinate(3, 3));

            var statusBeforeWinningTurn = game.GameState;
            game.TakeTurn(new Coordinate(1, 3));

            Assert.IsType<GameInProgress>(statusBeforeWinningTurn);
            Assert.IsType<GameWon>(game.GameState);
            Assert.Equal('X', game.CurrentPlayer.Symbol);
            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }
    }
}