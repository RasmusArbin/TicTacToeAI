using System;
using TicTacToe.Interfaces;
using TicTacToe.General;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace TicTacToe.General
{
    public class ComputerPlayer: IPlayer
    {
        const string storagePath = "moves.txt";
        public int PlayerNumber{get;private set;}
        Random _random = new Random();

        public ComputerPlayer(int playerNumber){
            PlayerNumber = playerNumber;
        }

        public Move Move(List<Move> previousMoves, int moveNumber){
            List<GameMoves> oldGameMoves = GetSavedGameMoves();

            List<GameMoves> winningMatchedMoves = oldGameMoves.Where(m => m.WinnerNumber.HasValue && m.WinnerNumber == PlayerNumber && m.Moves.Take(previousMoves.Count).SequenceEqual(previousMoves)).ToList();
            List<Move> loosingMatchedMoves = oldGameMoves.Where(m => m.WinnerNumber.HasValue && m.WinnerNumber != PlayerNumber && m.Moves.Take(previousMoves.Count).SequenceEqual(previousMoves)).SelectMany(m => m.Moves).ToList();

            if(previousMoves.Any() && winningMatchedMoves.Any()){
                // Console.WriteLine("Success!!");
                List<Move> availableMoves = winningMatchedMoves.Where(m => m.WinnerNumber == PlayerNumber).SelectMany(m => m.Moves).ToList();
                
                return availableMoves[_random.Next(availableMoves.Count)];
            }
            else{
                // Console.WriteLine("Fail!!");
                               
                List<Move> unionMoves = loosingMatchedMoves.Union(previousMoves).ToList();

                //Clear list if there are no way to win
                if(unionMoves.GroupBy(m => m.Row).Count() == 3 && unionMoves.GroupBy(m => m.Col).Count() == 3){
                    loosingMatchedMoves = new List<Move>();
                }

                return GetNewRandomMove(moveNumber, previousMoves, loosingMatchedMoves);
            }
        }

        private Move GetNewRandomMove(int moveNumber, List<Move> previousMoves, List<Move> avoidMoves){
            int col;
            int row;
            do{
                col = _random.Next(3);
                row = _random.Next(3);
            }
            while(previousMoves.Any(m => m.Row == row && m.Col == col) || avoidMoves.Any(m => m.Row == row && m.Col == col));

            return new Move(){
                Row = row,
                Col = col,
                MoveNumber = moveNumber,
                PlayerNumber = this.PlayerNumber
            };
        }

        private List<GameMoves> GetSavedGameMoves(){
            if (!File.Exists(storagePath))
            {
                string createText = JsonConvert.SerializeObject(new List<GameMoves>());
                File.WriteAllText(storagePath, createText);
            }

            return JsonConvert.DeserializeObject<List<GameMoves>>(File.ReadAllText(storagePath));
        }

        private void TryAppendSavedGameMoves(GameMoves gameMove){
            List<GameMoves> gameMoves = GetSavedGameMoves();

            if(!gameMoves.Contains(gameMove)){
                gameMoves.Add(gameMove);
                string strMoves = JsonConvert.SerializeObject(gameMoves);
                File.WriteAllText(storagePath, strMoves);
            }
        }

        public void AfterGameFinished(IGame game){
           TryAppendSavedGameMoves(new GameMoves(){
               Moves = game.Moves,
               WinnerNumber = game.Winner?.PlayerNumber
           });
        }
    }
}
