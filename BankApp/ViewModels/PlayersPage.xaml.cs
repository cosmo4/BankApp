using BankApp.Services;
using BankApp.Models;
using BankApp.ViewModels;

namespace BankApp;

public partial class PlayersPage : ContentPage
{
    private Game _game;
    public PlayersPage()
	{
		InitializeComponent();
        _game = App.ServiceProvider.GetService<GameService>().GetGame();
        updateBankTotal(_game.currentRound.total);
        PopulatePlayerNames(_game.players.OrderByDescending(p => p.points).ToList());

    }

    private void OnBankButtonClicked(int playerId)
    {
        _game.BankPlayerPoints(playerId);
        // Update the UI or notify the MainPage to refresh the grid
        PopulatePlayerNames(_game.players.OrderByDescending(p => p.points).ToList());
    }

    public void updateBankTotal(int currentTotal)
    {
        currentTotalLabel.Text = currentTotal.ToString();
    }

    private void PopulatePlayerNames(List<Player> players)
    {
        PlayersGrid.Children.Clear();
        PlayersGrid.RowDefinitions.Clear();

        for (int i = 0; i < players.Count; i++)
        {
            PlayersGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60) });

            var nameLabel = new Label
            {
                Text = players[i].playerName,
                FontSize = 20,
                Padding = new Thickness(0, 18),
                FontAttributes = FontAttributes.Bold

            };

            Grid.SetRow(nameLabel, i);
            Grid.SetColumn(nameLabel, 0);

            var pointsLabel = new Label
            {
                Text = players[i].points.ToString(),
                FontSize = 20,
                TextColor = Color.FromHex("#000000"),
                FontAttributes = FontAttributes.Bold,
                Padding = new Thickness(0, 18)

            };

            Grid.SetRow(pointsLabel, i);
            Grid.SetColumn(pointsLabel, 1);

            PlayersGrid.Children.Add(nameLabel);
            PlayersGrid.Children.Add(pointsLabel);

            if (players[i].isInRound)
            {
                var playerBankBtn = new Button
                {
                    Text = "BANK ME",
                    FontSize = 20,
                    Padding = new Thickness(5, 10),
                    BackgroundColor = Color.FromHex("#10ffcb"),
                    TextColor = Color.FromHex("#000000"),
                    FontAttributes = FontAttributes.Bold,
                    Command = new Command<int>(OnBankButtonClicked),
                    CommandParameter = players[i].id
                };

                Grid.SetRow(playerBankBtn, i);
                Grid.SetColumn(playerBankBtn, 2);

                PlayersGrid.Children.Add(playerBankBtn);
            }
                        
        }
    }
}