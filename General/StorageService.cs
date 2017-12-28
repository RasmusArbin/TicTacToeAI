using System;
using TicTacToe.Interfaces;
using TicTacToe.General;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace TicTacToe.General
{
    public static class StorageService
    {
        public static List<GameMoves> GameMoves{get; private set;}
        static StorageService(){
            GameMoves = GetSavedGameMoves();
        }

        const string storagePath = "moves.txt";

        private static List<GameMoves> GetSavedGameMoves(){
            if (!File.Exists(storagePath))
            {
                string createText = JsonConvert.SerializeObject(new List<GameMoves>());
                File.WriteAllText(storagePath, createText);
            }

            return JsonConvert.DeserializeObject<List<GameMoves>>(File.ReadAllText(storagePath));
        }

        public static void TryAppendSavedGameMoves(GameMoves gameMove){
            List<GameMoves> gameMoves = GameMoves;

            if(!gameMoves.Contains(gameMove)){
                gameMoves.Add(gameMove);
            }
        }

        public static void Save(){
            string strMoves = JsonConvert.SerializeObject(GameMoves);
            File.WriteAllText(storagePath, strMoves);
        }
    }
}
