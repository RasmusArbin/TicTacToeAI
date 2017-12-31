using System;
using TicTacToe.General;
using TicTacToe.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        private static IPlayer TranslateStringToPlayer(string player, int playerNumber){
            int intPlayer;
            int.TryParse(player, out intPlayer);

            switch ((GamePlayerEnum)intPlayer)
            {
                case GamePlayerEnum.ComputerPlayer:
                    return new ComputerPlayer(playerNumber);
                case GamePlayerEnum.HumanPlayer:
                    return new HumanPlayer(playerNumber);
                case GamePlayerEnum.RandomComputerPlayer:
                    return new RandomComputerPlayer(playerNumber);

                default:
                    return null;
            }
        }
        static void Main(string[] args)
        {
            int numberOfTimes;
            Console.WriteLine("Number of times");
            string strNumberOfTimes = Console.ReadLine();
            int.TryParse(strNumberOfTimes, out numberOfTimes);
            Console.WriteLine("Player 1");
            IPlayer player1 = TranslateStringToPlayer(Console.ReadLine(), 0);
            Console.WriteLine("Player 2");
            IPlayer player2 = TranslateStringToPlayer(Console.ReadLine(), 1);
            IPlayer winner;
            for(int i=0; i<numberOfTimes; i++){
                IGame game = new TicTacToeGame(player1, player2);

                while(!game.IsGameOver()){
                    game.NextPlayer();
                    game.Move();
                }

                // foreach (var item in game.Moves)
                // {
                //     Console.WriteLine(item);
                // }

                GameHelper.PrintMoves(game.Moves);

                Console.WriteLine($"Winner number: {game.Winner?.PlayerNumber}");

                winner = game.Winner;

                foreach (IPlayer player in game.Players)
                {
                    player.AfterGameFinished(game);
                }
            }

            StorageService.Save();
        }
    }
}
