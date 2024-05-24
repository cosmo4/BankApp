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

        public Player(string playerName) 
        { 
            this.playerName = playerName;
            points = 0;
            isInRound = true;
        }
    }
}
