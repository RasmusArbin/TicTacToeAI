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
