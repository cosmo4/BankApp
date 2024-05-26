using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Player
    {
        public string playerName;
        public int points;
        public bool isInRound;
        public int id;

        public Player(int id, string playerName) 
        { 
            this.id = id;
            this.playerName = playerName;
            points = 0;
            isInRound = true;
        }

        public void BankPoints(int roundTotal)
        {
            points += roundTotal;
            isInRound = false;
        }

    }
}
