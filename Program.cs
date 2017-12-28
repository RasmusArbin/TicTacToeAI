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
            IPlayer winner;
            do{
                IGame game = new TicTacToeGame(new ComputerPlayer(0), new ComputerPlayer(1));

                while(!game.IsGameOver()){
                    game.NextPlayer();
                    game.Move();
                }

                foreach (var item in game.Moves)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine($"Winner number: {game.Winner?.PlayerNumber}");

                winner = game.Winner;
            }
            while(winner == null);
        }
    }
}
