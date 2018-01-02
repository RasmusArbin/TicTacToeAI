using System;
using TicTacToe.Interfaces;
using TicTacToe.General;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace TicTacToe.General
{
    public class RandomComputerPlayer: IPlayer
    {
        const string storagePath = "moves.txt";
        public int PlayerNumber{get;private set;}
        Random _random = new Random();

        public RandomComputerPlayer(int playerNumber){
            PlayerNumber = playerNumber;
        }

        public Move Move(List<Move> previousMoves, int moveNumber){
            var move = GetNewRandomMove(moveNumber, previousMoves);

            return new Move(){
                Row = move.Row,
                Col = move.Col,
                PlayerNumber = PlayerNumber,
                MoveNumber = moveNumber
            };
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
                PlayerNumber = this.PlayerNumber
            };
        }

        public void AfterGameFinished(IGame game){
           StorageService.TryAppendSavedGameMoves(new GameMoves(){
               Moves = game.Moves,
               WinnerNumber = game.Winner?.PlayerNumber
           });
        }
    }
}
