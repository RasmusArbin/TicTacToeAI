using System;
using TicTacToe.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe.General
{
    public class TicTacToeGame: IGame
    {
        public List<IPlayer> Players {get; set;}
        public bool IsGameOver(){
            return true;
        }
        public IPlayer GetCurrentPlayer(){
            return null;
        }
        public void NextPlayer(){
            
        }
    }
}
