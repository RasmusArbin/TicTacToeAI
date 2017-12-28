using System;
using TicTacToe.Interfaces;
using TicTacToe.General;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace TicTacToe.General
{
    public class HumanPlayer: IPlayer
    {
        public int PlayerNumber{get;private set;}
        public HumanPlayer(int playerNumber){
            PlayerNumber = playerNumber;
        }

        public Move Move(List<Move> previousMoves, int moveNumber){
            int col = -1;
            int row = -1;
            do{
                PrintPreviousMoves(previousMoves);
                Console.WriteLine("Enter Row");
                string input = Console.ReadLine();
                if(int.TryParse(input, out row)){
                    Console.WriteLine("Enter Col");
                    input = Console.ReadLine();
                    if(!int.TryParse(input, out col)){
                        col = -1;  
                    }
                }
                else{
                    row = -1;
                }
            }
            while(row > -1 && row < 3 && col > -1 && col < 3 && previousMoves.Any(m => m.Row == row && m.Col == col));

            return new Move(){
                Col = col,
                Row = row,
                MoveNumber = moveNumber,
                PlayerNumber = PlayerNumber
            };
        }

        private void PrintPreviousMoves(List<Move> previousMoves){
            for(int r=0;r<3;r++){
                for(int c=0;c<3;c++){
                    Move move = previousMoves.FirstOrDefault(m => m.Row == r && m.Col == c);
                    Console.Write(move?.PlayerNumber.ToString() ?? "X");
                }   
                Console.WriteLine("");
            }
        }

        public void AfterGameFinished(IGame game){
            //Empty implementation
        }
    }
}
