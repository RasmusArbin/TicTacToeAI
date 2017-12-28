using System;
using TicTacToe.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe.General
{
    public class TicTacToeGame: IGame
    {
        const int MAX_MOVE_ID = 8;
        private Random _random = new Random();
        private bool _isGameOver = false;
        private int? _nextPlayerId = null;
        private int _moveId = 0;
        public List<IPlayer> Players {get;}
        
        public List<Move> Moves { get; private set; }
        
        public TicTacToeGame(params IPlayer[] players){
            this.Players = players.OrderBy(p => p.PlayerNumber).ToList();
            Moves = new List<Move>();
        }
        
        public bool IsGameOver(){
            return _isGameOver;
        }
        public IPlayer Winner{get;set;}
        public IPlayer GetCurrentPlayer(){
            return _nextPlayerId.HasValue ? Players[_nextPlayerId.Value] : null;
        }
        public void NextPlayer(){
            _nextPlayerId = _nextPlayerId.HasValue ? _nextPlayerId == (Players.Count - 1) ? 0 : _nextPlayerId + 1 : _random.Next(2);
        }

        private bool HasWon(IPlayer player){
            var moves = Moves.Where(m => m.PlayerNumber == player.PlayerNumber);

            var rGroup = moves.GroupBy(m => m.Row);

            if(rGroup.Any(g => g.Count() == 3) || (rGroup.Count() == 3 && rGroup.All(g => g.Count() == 1))){
                return true;
            }

            var cGroup = moves.GroupBy(m => m.Row);

            if(cGroup.Any(g => g.Count() == 3)|| (cGroup.Count() == 3 && cGroup.All(g => g.Count() == 1))){
                return true;
            }

            return false;
        }

        public void Move(){
            var currentPlayer = GetCurrentPlayer();
            Move move = currentPlayer.Move(Moves, _moveId);

            Moves.Add(move);

            _moveId++;

            bool won = HasWon(currentPlayer);

            _isGameOver = won || _moveId == MAX_MOVE_ID;

            if(won){
                Winner = currentPlayer;
            }
        }
    }
}
