using System;
using System.Collections.Generic;
using TicTacToe.General;

namespace TicTacToe.Interfaces
{
    public interface IGame
    {
        List<IPlayer> Players {get;}
        bool IsGameOver();
        IPlayer Winner{get;}
        IPlayer GetCurrentPlayer();
        void NextPlayer();
        void Move();
        List<Move> Moves {get;}
    }
}
