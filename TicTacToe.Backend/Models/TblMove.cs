using System;
using System.Collections.Generic;

namespace TicTacToe.Backend.Models
{
    public partial class TblMove
    {
        public int MoveId { get; set; }
        public int GameId { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public int PlayerNumber { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int MoveNumber { get; set; }

        public TblGame Game { get; set; }

        public TblMove()
        {
            Created = Modified = DateTime.Now;
        }
    }
}
