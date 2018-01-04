using System;
using TicTacToe.Interfaces;
using TicTacToe.General;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using TicTacToe.Backend.Models;
using TicTacToe.Backend.Services;

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

        public TblMove Move(List<TblMove> previousMoves, int moveNumber){
            var move = GetNewRandomMove(moveNumber, previousMoves);

            return new TblMove(){
                Row = move.Row,
                Col = move.Col,
                PlayerNumber = PlayerNumber,
                MoveNumber = moveNumber
            };
        }

        private TblMove GetNewRandomMove(int moveNumber, List<TblMove> previousMoves){
            int col;
            int row;
            do{
                col = _random.Next(3);
                row = _random.Next(3);
            }
            while(previousMoves.Any(m => m.Row == row && m.Col == col));

            return new TblMove(){
                Row = row,
                Col = col,
                MoveNumber = moveNumber,
                PlayerNumber = this.PlayerNumber
            };
        }

        public void AfterGameFinished(IGame game){
            TblGame tblGame = new TblGame()
            {
                WinnerPlayerNumber = game.Winner?.PlayerNumber
            };

            foreach (var move in game.Moves)
            {
                tblGame.TblMove.Add(move);
            }

            Providers.ServiceProvider.GetService<GameService>().TryAppendSavedGameMoves(tblGame);
        }
    }
}
