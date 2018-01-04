using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToe.Backend.Interfaces;

namespace TicTacToe.Backend.Models
{
    public partial class TblGame : IBaseBO
    {
        public int StartingPlayerNumber
        {
            get
            {
                return TblMove.First().PlayerNumber;
            }
        }
        public int Id => GameId;
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            TblGame game = (TblGame)obj;
            return WinnerPlayerNumber == game.WinnerPlayerNumber && TblMove.SequenceEqual(game.TblMove);
        }

        public override int GetHashCode()
        {
            int hashCode = WinnerPlayerNumber?.GetHashCode() ?? 0;

            foreach (TblMove move in TblMove)
            {
                hashCode += move.GetHashCode();
            }

            return hashCode;
        }

        public bool IsWinner(bool started)
        {

            if (!WinnerPlayerNumber.HasValue)
            {
                return false;
            }

            return (started && WinnerPlayerNumber == StartingPlayerNumber) ||
                   (!started && WinnerPlayerNumber != StartingPlayerNumber);
        }
    }
}
