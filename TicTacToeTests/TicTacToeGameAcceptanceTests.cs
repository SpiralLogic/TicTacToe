﻿using TicTacToe;
using TicTacToe.GameState;
using TicTacToe.TurnStatus;
using Xunit;
using Coordinate = System.Drawing.Point;

namespace TicTacToeTests
{
    public class TicTacToeGameAcceptanceTests
    {
        [Fact]
        public void GameCanBeADraw()
        {
            string[] expectedInitalBoard =
            {
                ". . .",
                ". . .",
                ". . ."
            };

            string[] expectedBoard1 =
            {
                ". . .",
                ". X .",
                ". . ."
            };

            string[] expectedBoard3 =
            {
                ". . .",
                ". X .",
                ". . O"
            };

            string[] expectedBoard4 =
            {
                ". . .",
                ". X X",
                ". . O"
            };

            string[] expectedBoard5 =
            {
                ". . .",
                ". X X",
                ". O O"
            };

            string[] expectedBoard6 =
            {
                ". X .",
                ". X X",
                ". O O"
            };

            string[] expectedBoard7 =
            {
                ". X .",
                "O X X",
                ". O O"
            };

            string[] expectedBoard8 =
            {
                "X X .",
                "O X X",
                ". O O"
            };

            string[] expectedBoard9 =
            {
                "X X O",
                "O X X",
                ". O O"
            };
            string[] expectedBoard10 =
            {
                "X X O",
                "O X X",
                "X O O"
            };

            var game = new TicTacToeGame();
            Assert.Equal(string.Join('\n', expectedInitalBoard), game.DescribeBoard());

            game.TakeTurn(new Coordinate(2, 2));
            Assert.Equal(string.Join('\n', expectedBoard1), game.DescribeBoard());

            game.TakeTurn(new Coordinate(3, 3));
            Assert.Equal(string.Join('\n', expectedBoard3), game.DescribeBoard());

            game.TakeTurn(new Coordinate(2, 3));
            Assert.Equal(string.Join('\n', expectedBoard4), game.DescribeBoard());

            game.TakeTurn(new Coordinate(3, 2));
            Assert.Equal(string.Join('\n', expectedBoard5), game.DescribeBoard());

            game.TakeTurn(new Coordinate(1, 2));
            Assert.Equal(string.Join('\n', expectedBoard6), game.DescribeBoard());

            game.TakeTurn(new Coordinate(2, 1));
            Assert.Equal(string.Join('\n', expectedBoard7), game.DescribeBoard());

            game.TakeTurn(new Coordinate(1, 1));
            Assert.Equal(string.Join('\n', expectedBoard8), game.DescribeBoard());

            game.TakeTurn(new Coordinate(1, 3));
            Assert.Equal(string.Join('\n', expectedBoard9), game.DescribeBoard());

            Assert.IsType<TurnSuccess>(game.TakeTurn(new Coordinate(3, 1)));
            Assert.IsType<GameDraw>(game.GameState);
            Assert.Equal(string.Join('\n', expectedBoard10), game.DescribeBoard());
        }

        [Fact]
        public void Player1CanWinTheGame()
        {
            string[] expectedInitialBoard =
            {
                ". . .",
                ". . .",
                ". . ."
            };

            string[] expectedBoard1 =
            {
                "X . .",
                ". . .",
                ". . ."
            };

            string[] expectedBoard2 =
            {
                "X . .",
                ". . .",
                ". . O"
            };

            string[] expectedBoard3 =
            {
                "X . .",
                ". . .",
                "X . O"
            };

            string[] expectedBoard4 =
            {
                "X . .",
                "O . .",
                "X . O"
            };

            string[] expectedBoard5 =
            {
                "X . .",
                "O X .",
                "X . O"
            };

            string[] expectedBoard6 =
            {
                "X . .",
                "O X .",
                "X O O"
            };
            string[] expectedFinalBoard =
            {
                "X . X",
                "O X .",
                "X O O"
            };

            var game = new TicTacToeGame();
            Assert.Equal(string.Join('\n', expectedInitialBoard), game.DescribeBoard());

            game.TakeTurn(new Coordinate(1, 1));
            Assert.Equal(string.Join('\n', expectedBoard1), game.DescribeBoard());

            game.TakeTurn(new Coordinate(3, 3));
            Assert.Equal(string.Join('\n', expectedBoard2), game.DescribeBoard());

            game.TakeTurn(new Coordinate(3, 1));
            Assert.Equal(string.Join('\n', expectedBoard3), game.DescribeBoard());

            game.TakeTurn(new Coordinate(2, 1));
            Assert.Equal(string.Join('\n', expectedBoard4), game.DescribeBoard());

            game.TakeTurn(new Coordinate(2, 2));
            Assert.Equal(string.Join('\n', expectedBoard5), game.DescribeBoard());

            game.TakeTurn(new Coordinate(3, 2));
            Assert.Equal(string.Join('\n', expectedBoard6), game.DescribeBoard());

            Assert.IsType<TurnSuccess>(game.TakeTurn(new Coordinate(1, 3)));
            Assert.IsType<GameWon>(game.GameState);
            Assert.Equal(string.Join('\n', expectedFinalBoard), game.DescribeBoard());
        }

        [Fact]
        public void Player2CanWinTheGame()
        {
            string[] expectedInitialBoard =
            {
                ". . .",
                ". . .",
                ". . ."
            };

            string[] expectedBoard1 =
            {
                "X . .",
                ". . .",
                ". . ."
            };

            string[] expectedBoard2 =
            {
                "X . .",
                ". . .",
                ". . O"
            };

            string[] expectedBoard4 =
            {
                "X . .",
                ". . .",
                "X . O"
            };

            string[] expectedBoard5 =
            {
                "X . .",
                ". . O",
                "X . O"
            };

            string[] expectedBoard6 =
            {
                "X . .",
                ". X O",
                "X . O"
            };

            string[] expectedBoard7 =
            {
                "X . O",
                ". X O",
                "X . O"
            };

            var game = new TicTacToeGame();
            Assert.Equal(string.Join('\n', expectedInitialBoard), game.DescribeBoard());

            game.TakeTurn(new Coordinate(1, 1));
            Assert.Equal(string.Join('\n', expectedBoard1), game.DescribeBoard());

            game.TakeTurn(new Coordinate(3, 3));
            Assert.Equal(string.Join('\n', expectedBoard2), game.DescribeBoard());

            game.TakeTurn(new Coordinate(3, 1));
            Assert.Equal(string.Join('\n', expectedBoard4), game.DescribeBoard());

            game.TakeTurn(new Coordinate(2, 3));
            Assert.Equal(string.Join('\n', expectedBoard5), game.DescribeBoard());

            game.TakeTurn(new Coordinate(2, 2));
            Assert.Equal(string.Join('\n', expectedBoard6), game.DescribeBoard());

            Assert.IsType<TurnSuccess>(game.TakeTurn(new Coordinate(1, 3)));
            Assert.IsType<GameWon>(game.GameState);
            Assert.Equal(string.Join('\n', expectedBoard7), game.DescribeBoard());
        }
    }
}