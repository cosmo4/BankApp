using BankApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BankApp.ViewModels
{
    public partial class ViewPlayersModel : ObservableObject
    {
        // Allows changes to be reflected elsewhere
        [ObservableProperty]
        List<Player> players;

        public ViewPlayersModel() 
        {
            //LoadPlayers();
        }

        //private void LoadPlayers()
        //{
        //    Players = new()
        //    {
        //        new Player(playerName: "Luke"),
        //        new Player(playerName: "Seth"),
        //        new Player(playerName: "Anna")
        //    };
        //}
    }
}
