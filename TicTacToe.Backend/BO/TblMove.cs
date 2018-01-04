using System;
using TicTacToe.Backend.Interfaces;

namespace TicTacToe.Backend.Models
{
    public partial class TblMove : IBaseBO
    {
        public int Id => MoveId;
        
        public override string ToString()
        {
            return $"Number: {MoveNumber}, Row: {Row}, Col {Col}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            TblMove move = (TblMove)obj;
            return move.MoveNumber == MoveNumber && move.Row == Row && move.Col == Col;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
