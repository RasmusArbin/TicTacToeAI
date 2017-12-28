using System;
using TicTacToe.General;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe.General
{
    public class GameMoves
    {
        public List<Move> Moves{get;set;}
        public int? WinnerNumber{get;set;}

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            GameMoves moves = (GameMoves)obj;
            return WinnerNumber == moves.WinnerNumber && Moves.SequenceEqual(moves.Moves);
        }
        
        public override int GetHashCode()
        {
            int hashCode = WinnerNumber?.GetHashCode() ?? 0;

            foreach (Move move in Moves)
            {
                hashCode += move.GetHashCode();
            }

            return hashCode;
        }
    }
}
