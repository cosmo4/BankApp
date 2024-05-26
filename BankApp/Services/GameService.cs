using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public class GameService
    {
        private Game _game;

        public GameService()
        {
            _game = new Game(new List<Player>
            {
                new Player(0, "Pla1"),
                new Player(1, "Pla2"),
                new Player(2, "Pla3"),
                new Player(3, "Pla4")
            });
        }

        public Game GetGame()
        {
            return _game;
        }
    }
}
