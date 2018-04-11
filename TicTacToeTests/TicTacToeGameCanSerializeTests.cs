using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using TicTacToe;
using TicTacToe.GameState;
using Xunit;

namespace TicTacToeTests
{
    public class TicTacToeGameCanSerializeTests
    {
        [Fact]
        public void WhenSerializingPlayer1IsSerialized()
        {
            var game = new TicTacToeGame(3, new Player("Player 1", 'X'), new Player("Player 2", 'O'));
            var stream1 = new MemoryStream();
            var settings = new DataContractJsonSerializerSettings();
            settings.KnownTypes = new List<Type>
            {
                typeof(GameInProgress),
                typeof(GameDraw),
                typeof(GameForfeit),
                typeof(Player),
                typeof(GameWon),
                typeof(EmptyCoordinate)
            };
            settings.SerializeReadOnlyTypes = true;
            
            var ser = new DataContractJsonSerializer(typeof(TicTacToeGame), settings);
            ser.WriteObject(stream1, game);

            stream1.Position = 0;
            var sr = new StreamReader(stream1);
            var result = sr.ReadToEnd();
            Assert.Equal("X", result);
        }
    }
}