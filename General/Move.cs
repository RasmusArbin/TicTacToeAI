using System;
using TicTacToe.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.General
{
    public class Move
    {
        public int MoveNumber { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public IPlayer Player { get; set; }

        public override string ToString(){
            return $"Number: {MoveNumber}, Row: {Row}, Col {Col}";
        }
    }
}
