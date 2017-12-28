using System;
using TicTacToe.Interfaces;
using TicTacToe.General;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.General
{
    public class ComputerPlayer: IPlayer
    {
        public int PlayerNumber{get;private set;}
        Random _random = new Random();

        public ComputerPlayer(int playerNumber){
            PlayerNumber = playerNumber;
        }

        public Move Move(List<Move> previousMoves, int moveNumber){ 
            return GetNewRandomMove(moveNumber, previousMoves);
        }

        private Move GetNewRandomMove(int moveNumber, List<Move> previousMoves){
            int col;
            int row;
            do{
                col = _random.Next(3);
                row = _random.Next(3);
            }
            while(previousMoves.Any(m => m.Row == row && m.Col == col));

            return new Move(){
                Row = row,
                Col = col,
                MoveNumber = moveNumber,
                Player = this
            };
        }
    }
}
