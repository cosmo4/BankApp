using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.ViewModels;

namespace BankApp.Models
{
    public class Game
    {
        public List<Player> players;
        public int currentRoundNumber;
        public Round currentRound;
        public int nextStartingPlayerIndex;
        public int mostRollsInRound;
        public int mostPointsInRound;
        public int gameLength;
        public int currentPlayerIndex;

        public event Action<int> BankTotalUpdated;
        public event Action<int> NewRoundStarted;
        public event Action<int> CurrentPlayerChanged;

        public Game(List<Player> players)
        {
            this.players = players;
            currentRoundNumber = 1;
            gameLength = 15;
            currentPlayerIndex = 0;
            nextStartingPlayerIndex = 0;
            mostRollsInRound = 0;
            StartNewRound();
        }

        public void StartNewRound()
        {
            do
            {
                currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            } while (!players[currentPlayerIndex].isInRound);

            // Set the next player as active
            players[currentPlayerIndex].isInRound = true;

            currentRound = new Round(currentRoundNumber, players, nextStartingPlayerIndex);

            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;

            BankTotalUpdated?.Invoke(0);
            NewRoundStarted?.Invoke(currentRound.rollCount);
            NewRoundStarted?.Invoke(currentPlayerIndex);
            currentRoundNumber++;
        }

        public void EndCurrentRound()
        {
            if (currentRound.rollCount > mostRollsInRound)
            {
                mostRollsInRound = currentRound.rollCount;
            }

            if (currentRound.total > mostPointsInRound)
            {
                mostPointsInRound = currentRound.total;
            }

            currentRound.EndRound();
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;

            if (currentRoundNumber < gameLength)
            {
                StartNewRound();
            }
            else
            {
                // Run Game over method, display game over, show leaderboard
            }
        }

        public void BankPlayerPoints(int playerId)
        {
            var player = players.FirstOrDefault(p => p.id == playerId);
            if (player != null)
            {
                player.points += currentRound.total;
                player.isInRound = false;
                AdvanceToNextPlayer();
                // Trigger an update to refresh the UI or any other necessary logic
                BankTotalUpdated?.Invoke(currentRound.total);
            }
        }

        public void AdvanceToNextPlayer()
        {
            // Increment the current player index
            do
            {
                currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            } while (!players[currentPlayerIndex].isInRound);

            // Trigger the event to notify subscribers that the current player has changed
            CurrentPlayerChanged?.Invoke(currentPlayerIndex);
        }

        public void GameOver()
        {
            // TODO add stuff here
        }

        //public void PlayRound()
        //{
        //    // Implement game play logic here
        //    // E.g., currentRound.Roll(points);

        //    // Check if round is over and start a new round if necessary
        //    if (currentRound.CheckIfRoundIsOver())
        //    {
        //        EndCurrentRound();
                
        //    }
        //}


    }
}
