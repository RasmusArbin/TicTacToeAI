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
        public int PlayerNumber { get; set; }

        public override string ToString(){
            return $"Number: {MoveNumber}, Row: {Row}, Col {Col}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            Move move = (Move)obj;
            return move.MoveNumber == MoveNumber && move.Row == Row && move.Col == Col;
        }
        
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
