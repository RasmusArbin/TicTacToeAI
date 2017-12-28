using System;
using TicTacToe.General;
using TicTacToe.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTimes = 1;
            int.TryParse(args[0], out numberOfTimes);
            IPlayer winner;
            for(int i=0; i<numberOfTimes; i++){
                IGame game = new TicTacToeGame(new HumanPlayer(0), new ComputerPlayer(1));

                while(!game.IsGameOver()){
                    game.NextPlayer();
                    game.Move();
                }

                // foreach (var item in game.Moves)
                // {
                //     Console.WriteLine(item);
                // }

                // Console.WriteLine($"Winner number: {game.Winner?.PlayerNumber}");

                winner = game.Winner;

                foreach (IPlayer player in game.Players)
                {
                    player.AfterGameFinished(game);
                }
            }
        }
    }
}
