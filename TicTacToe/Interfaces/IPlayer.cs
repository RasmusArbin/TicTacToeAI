using System.Collections.Generic;
using TicTacToe.Backend.Models;

namespace TicTacToe.Interfaces
{
    public interface IPlayer
    {
        int PlayerNumber{get;}
        TblMove Move(List<TblMove> previousMoves, int moveId);
        void AfterGameFinished(IGame game);
    }
}
