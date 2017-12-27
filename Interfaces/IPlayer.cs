using System;
using System.Collections.Generic;

namespace TicTacToe.Interfaces
{
    public interface IPlayer
    {
        Dictionary<int, int[][]> Moves {get; set;}
        void Move(int moveId);
    }
}
