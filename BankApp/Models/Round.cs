using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.ViewModels;

namespace BankApp.Models
{
    public class Round
    {
        public int total;
        public int roundNumber;
        public int rollCount;
        public bool isNotOver;
        public List<Player> players;
        public int currentPlayerIndex;

        public Round(int roundNumber, List<Player> players, int startingPlayerIndex)
        {
            this.roundNumber = roundNumber;
            this.players = players;
            rollCount = 0;
            total = 0;
            currentPlayerIndex = startingPlayerIndex;
            isNotOver = true;
            foreach (Player player in players)
            {
                player.isInRound = true;
            }

        }

        public void Roll(int points)
        {
            if (!isNotOver) throw new InvalidOperationException("The round is over.");
            total += points;
            NextTurn();
            rollCount++;
        }

        public void NextTurn()
        {
            if (!isNotOver) throw new InvalidOperationException("The round is over.");
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
        }

        public void EndRound()
        {
            total = 0;
            isNotOver = false;
        }

        public void StartRound(int startingPlayerIndex)
        {
            total = 0;
            rollCount = 0;
            isNotOver = true;
            currentPlayerIndex = startingPlayerIndex;
            foreach (var player in players)
            {
                player.isInRound = true;
            }
        }

        public bool CheckIfRoundIsOver()
        {
            if (roundNumber > 3 || players.Count == 0)
            {
                return true;

            }
            else
            {
                return false;

            }

        }

        public int GetCurrentPlayerIndex()
        {
            return currentPlayerIndex;
        }
    }
}
