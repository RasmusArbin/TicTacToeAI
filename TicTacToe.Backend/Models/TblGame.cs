using System;
using System.Collections.Generic;

namespace TicTacToe.Backend.Models
{
    public partial class TblGame
    {
        public TblGame()
        {
            TblMove = new HashSet<TblMove>();
            Created = Modified = DateTime.Now;
        }

        public int GameId { get; set; }
        public int? WinnerPlayerNumber { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public ICollection<TblMove> TblMove { get; set; }
    }
}
