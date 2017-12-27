using System;
using System.Collections.Generic;

namespace TicTacToe.Interfaces
{
    public interface IGame
    {
        List<IPlayer> Players {get; set;}
        bool IsGameOver();
        IPlayer GetCurrentPlayer();
        void NextPlayer();
    }
}
