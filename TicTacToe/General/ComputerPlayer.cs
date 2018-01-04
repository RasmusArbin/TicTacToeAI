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
    public class ComputerPlayer: IPlayer
    {
        //const string storagePath = "moves.txt";
        public int PlayerNumber{get;private set;}
        Random _random = new Random();
        bool _started = false;

        public ComputerPlayer(int playerNumber){
            PlayerNumber = playerNumber;
        }

        public TblMove Move(List<TblMove> previousMoves, int moveNumber){

            if(moveNumber == 0){
                _started = true;
            }

            List<TblGame> oldGameMoves = Providers.ServiceProvider.GetService<GameService>().GetAll();

            List<TblMove> winningMatchedMoves = oldGameMoves.Where(m => m.IsWinner(_started) && m.TblMove.Take(previousMoves.Count).SequenceEqual(previousMoves)).SelectMany(m => m.TblMove).Where(m => m.MoveNumber == moveNumber).ToList();
            List<TblMove> loosingMatchedMoves = oldGameMoves.Where(m => m.IsWinner(_started) && m.TblMove.Take(previousMoves.Count).SequenceEqual(previousMoves)).SelectMany(m => m.TblMove).Where(m => m.MoveNumber == moveNumber).ToList();

            TblMove move = null;

            if(winningMatchedMoves.Any()){
                // Console.WriteLine("Success!!");
                List<TblMove> availableMoves = winningMatchedMoves.Where(m => m.MoveNumber == moveNumber).ToList();
                
                move = availableMoves.GroupBy(m => m).OrderByDescending(g => g.Count()).Select(x => x.Key).First();
            }
            else{
                // Console.WriteLine("Fail!!");
                               
                List<TblMove> unionMoves = loosingMatchedMoves.Union(previousMoves).ToList();

                List<IGrouping<int, TblMove>> gRMoves = unionMoves.GroupBy(m => m.Row).ToList();
                List<IGrouping<int, TblMove>> gCMoves = unionMoves.GroupBy(m => m.Col).ToList();

                //Clear list if there are no way to win
                if(loosingMatchedMoves.Any() && gRMoves.Count == 3 && gRMoves.All(g => g.Count() == 3) && gCMoves.Count == 3 && gCMoves.All(g => g.Count() == 3)){
                    move = loosingMatchedMoves.GroupBy(m => m).OrderBy(g => g.Count()).Select(g => g.Key).First();
                }
                else{
                    move = GetNewRandomMove(moveNumber, previousMoves, loosingMatchedMoves);
                }
            }

            return new TblMove(){
                Row = move.Row,
                Col = move.Col,
                PlayerNumber = PlayerNumber,
                MoveNumber = moveNumber
            };
        }

        private TblMove GetNewRandomMove(int moveNumber, List<TblMove> previousMoves, List<TblMove> avoidMoves){
            int col;
            int row;
            do{
                col = _random.Next(3);
                row = _random.Next(3);
            }
            while(previousMoves.Any(m => m.Row == row && m.Col == col) || avoidMoves.Any(m => m.Row == row && m.Col == col));

            return new TblMove(){
                Row = row,
                Col = col,
                MoveNumber = moveNumber,
                PlayerNumber = this.PlayerNumber
            };
        }

        public void AfterGameFinished(IGame game)
        {
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
