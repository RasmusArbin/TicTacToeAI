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
        private int _nextPlayerId = 0;
        private int _moveId = 0;
        public List<IPlayer> Players {get;}
        
        public List<Move> Moves { get; private set; }
        
        public TicTacToeGame(params IPlayer[] players){
            this.Players = players.OrderBy(p => Guid.NewGuid()).ToList();
            Moves = new List<Move>();
        }
        
        public bool IsGameOver(){
            return _isGameOver;
        }
        public IPlayer Winner{get;set;}
        public IPlayer GetCurrentPlayer(){
            return Players[_nextPlayerId];
        }
        public void NextPlayer(){
            _nextPlayerId = _nextPlayerId == (Players.Count - 1) ? 0 : _nextPlayerId + 1;
        }

        private bool HasWon(IPlayer player){
            var moves = Moves.Where(m => m.PlayerNumber == player.PlayerNumber).ToList();

            var rGroup = moves.GroupBy(m => m.Row);

            if(rGroup.Any(g => g.Count() == 3)){
                return true;
            }

            var cGroup = moves.GroupBy(m => m.Col);

            if(cGroup.Any(g => g.Count() == 3)){
                return true;
            }

            //Cross
            if((moves.Any(m => m.Col == 0 && m.Row == 0) && moves.Any(m => m.Col == 1 && m.Row == 1) && moves.Any(m => m.Col == 2 && m.Row == 2)) ||
               (moves.Any(m => m.Col == 0 && m.Row == 2) && moves.Any(m => m.Col == 1 && m.Row == 1) && moves.Any(m => m.Col == 2 && m.Row == 0))
            ){
                return true;
            }

            return false;
        }

        public void Move(){
            var currentPlayer = GetCurrentPlayer();
            Move move = currentPlayer.Move(Moves, _moveId);

            Moves.Add(move);

            bool won = HasWon(currentPlayer);

            _isGameOver = won || _moveId == MAX_MOVE_ID;

            if(won){
                Winner = currentPlayer;
            }

            _moveId++;
        }
    }
}
