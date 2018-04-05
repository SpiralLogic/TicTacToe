using System;
using TicTacToe;
using TicTacToe.GameState;
using Coordinate = System.Drawing.Point;

namespace TicTacToeConsole
{
    internal class Program
    {
        private const string GameForfeitChar = "q";
        private readonly TicTacToeGame _game = new TicTacToeGame(3);

        private static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        private void Run()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");

            while (_game.GameState is GameInProgress) NextTurn();

            Console.WriteLine(_game.GameState.Describe);
            Console.WriteLine(_game.DescribeBoard());
        }

        private void NextTurn()
        {
            Console.WriteLine("Here's the current board:");
            Console.WriteLine(_game.DescribeBoard());
            Console.WriteLine(_game.GameState.Describe);
            Console.Write("Enter next turn: ");

            var input = Console.ReadLine();
            Console.WriteLine();
            
            if (!IsValidInput(input))
            {
                Console.WriteLine("Invalid Input");

                return;
            }

            if (input == GameForfeitChar)
            {
                _game.ForfeitGame();

                return;
            }

            var coordinate = CreateCoordinate(input);
            var turnStatus = _game.TakeTurn(coordinate);
            
            Console.Write($"{turnStatus.Describe} ");
        }

        private Coordinate CreateCoordinate(string input)
        {
            var coordinateInputs = input.Split(',');
            var x = int.Parse(coordinateInputs[0].Trim());
            var y = int.Parse(coordinateInputs[1].Trim());

            return new Coordinate(x, y);
        }

        private bool IsValidInput(string input)
        {
            if (input.Trim() == GameForfeitChar) return true;

            var splitInput = input.Split(',');

            if (splitInput.Length != 2) return false;

            if (!int.TryParse(splitInput[0].Trim(), out _)) return false;

            if (!int.TryParse(splitInput[1].Trim(), out _)) return false;

            return true;
        }
    }
}