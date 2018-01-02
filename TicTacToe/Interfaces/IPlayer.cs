using System;
using System.Collections.Generic;
using TicTacToe.General;

namespace TicTacToe.Interfaces
{
    public interface IPlayer
    {
        int PlayerNumber{get;}
        Move Move(List<Move> previousMoves, int moveId);
        void AfterGameFinished(IGame game);
    }
}
