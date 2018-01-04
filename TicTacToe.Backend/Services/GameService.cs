using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TicTacToe.Backend.Models;
using TicTacToe.Backend.Services;

namespace TicTacToe.Backend.Services
{
    public class GameService: TicTacToeService
    {
        public List<TblGame> GetAll()
        {
            return ReadQuery(RepositoryProvider.GetRepository<TblGame>().GetAll().Include(g => g.TblMove));
        }

        public void TryAppendSavedGameMoves(TblGame game)
        {
            List<TblGame> gameMoves = GetAll();

            if (!gameMoves.Contains(game))
            {
                RepositoryProvider.GetRepository<TblGame>().Insert(game);
            }
        }
    }
}
