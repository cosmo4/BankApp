using BankApp.Models;
using BankApp.ViewModels;
using BankApp.Services;
using System;

namespace BankApp
{
    public partial class MainPage : ContentPage
    {
        private Game _game;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ViewPlayersModel();

            _game = App.ServiceProvider.GetService<GameService>().GetGame();
            _game.BankTotalUpdated += UpdateBankTotal;
            _game.NewRoundStarted += ButtonDisabler;
            UpdateBankTotal(_game.currentRound.total);
            ButtonDisabler(_game.currentRound.rollCount);
            UpdateTurnLabel();
        }

        public void ButtonDisabler(int rollNumber)
        {
            if (rollNumber < 3)
            {
                doublesBtn.IsEnabled = false;
                sevenBtn.BackgroundColor = Color.FromHex("#10ffcb");
                twoBtn.IsEnabled = true;
                twelveBtn.IsEnabled = true;
            }
            else
            {
                doublesBtn.IsEnabled = true;
                twoBtn.IsEnabled = false;
                twelveBtn.IsEnabled = false;
                sevenBtn.BackgroundColor = Color.FromHex("#ed474a");
            }
        }

        async void OnDoublesButtonClicked(object sender, EventArgs e)
        {
            int currentTotal = _game.currentRound.total;
            _game.currentRound.Roll(currentTotal);
            currentTotal += currentTotal;
            UpdateBankTotal(currentTotal);

            foreach (var child in ButtonGrid.Children)
            {
                if (child is Button button)
                {
                    button.IsEnabled = false;
                }
            }

            var animationTasks = new Task[ButtonGrid.Children.Count];
            int index = 0;
            foreach (var child in ButtonGrid.Children)
            {
                if (child is Button button)
                {
                    animationTasks[index] = GrowAndRotateButton(button);
                    index++;
                }
            }

            // Await all animation tasks to run simultaneously
            await Task.WhenAll(animationTasks);

            foreach (var child in ButtonGrid.Children)
            {
                if (child is Button button)
                {
                    button.IsEnabled = true;
                }
            }
            ButtonDisabler(_game.currentRound.rollCount);
            _game.AdvanceToNextPlayer();
            UpdateTurnLabel();
        }

        async Task GrowAndRotateButton(Button button)
        {
            await Task.WhenAll(
                button.RotateTo(360, 500),
                button.ScaleTo(1.2, 250)
                );
            await Task.WhenAll(
                button.ScaleTo(1, 100)
                );
            button.Rotation = 0;
        }

        #region number buttons clicked code

        private void OnTwoBtnClicked(object sender, EventArgs e) 
        {
            _game.currentRound.Roll(2);
            int currentTotal = _game.currentRound.total;
            UpdateBankTotal(currentTotal);
            ButtonDisabler(_game.currentRound.rollCount);
            _game.AdvanceToNextPlayer();
            UpdateTurnLabel();
        }

        private void OnThreeBtnClicked(object sender, EventArgs e)
        {
            _game.currentRound.Roll(3);
            int currentTotal = _game.currentRound.total;
            UpdateBankTotal(currentTotal);
            ButtonDisabler(_game.currentRound.rollCount);
            _game.AdvanceToNextPlayer();
            UpdateTurnLabel();
        }

        private void OnFourBtnClicked(object sender, EventArgs e)
        {
            _game.currentRound.Roll(4);
            int currentTotal = _game.currentRound.total;
            UpdateBankTotal(currentTotal);
            ButtonDisabler(_game.currentRound.rollCount);
            _game.AdvanceToNextPlayer();
            UpdateTurnLabel();
        }

        private void OnFiveBtnClicked(object sender, EventArgs e)
        {
            _game.currentRound.Roll(5);
            int currentTotal = _game.currentRound.total;
            UpdateBankTotal(currentTotal);
            ButtonDisabler(_game.currentRound.rollCount);
            _game.AdvanceToNextPlayer();
            UpdateTurnLabel();
        }

        private void OnSixBtnClicked(object sender, EventArgs e)
        {
            _game.currentRound.Roll(6);
            int currentTotal = _game.currentRound.total;
            UpdateBankTotal(currentTotal);
            ButtonDisabler(_game.currentRound.rollCount);
            _game.AdvanceToNextPlayer();
            UpdateTurnLabel();
        }

        private void OnSevenBtnClicked(object sender, EventArgs e)
        {
            if (_game.currentRound.rollCount < 3) 
            {
                _game.currentRound.Roll(70);
                int currentTotal = _game.currentRound.total;
                UpdateBankTotal(currentTotal);
                ButtonDisabler(_game.currentRound.rollCount);
                _game.AdvanceToNextPlayer();
                UpdateTurnLabel();
            }
            else
            {
                _game.AdvanceToNextPlayer();
                UpdateTurnLabel();
                _game.EndCurrentRound();
            }
        }

        private void OnEightBtnClicked(object sender, EventArgs e)
        {
            _game.currentRound.Roll(8);
            int currentTotal = _game.currentRound.total;
            UpdateBankTotal(currentTotal);
            ButtonDisabler(_game.currentRound.rollCount);
            _game.AdvanceToNextPlayer();
            UpdateTurnLabel();
        }

        private void OnNineBtnClicked(object sender, EventArgs e)
        {
            _game.currentRound.Roll(9);
            int currentTotal = _game.currentRound.total;
            UpdateBankTotal(currentTotal);
            ButtonDisabler(_game.currentRound.rollCount);
            _game.AdvanceToNextPlayer();
            UpdateTurnLabel();
        }

        private void OnTenBtnClicked(object sender, EventArgs e)
        {
            _game.currentRound.Roll(10);
            int currentTotal = _game.currentRound.total;
            UpdateBankTotal(currentTotal);
            ButtonDisabler(_game.currentRound.rollCount);
            _game.AdvanceToNextPlayer();
            UpdateTurnLabel();
        }

        private void OnElevenBtnClicked(object sender, EventArgs e)
        {
            _game.currentRound.Roll(11);
            int currentTotal = _game.currentRound.total;
            UpdateBankTotal(currentTotal);
            ButtonDisabler(_game.currentRound.rollCount);
            _game.AdvanceToNextPlayer();
            UpdateTurnLabel();
        }

        private void OnTwelveBtnClicked(object sender, EventArgs e)
        {
            _game.currentRound.Roll(12);
            int currentTotal = _game.currentRound.total;
            UpdateBankTotal(currentTotal);
            ButtonDisabler(_game.currentRound.rollCount);
            _game.AdvanceToNextPlayer();
            UpdateTurnLabel();
        }
        #endregion

        private async void OnPlayersBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayersPage());
            
        }

        public void UpdateBankTotal(int currentTotal)
        {
            currentTotalLabel.Text = currentTotal.ToString();
        }

        private void UpdateTurnLabel()
        {
            // Get the name of the current player
            string currentPlayerName = _game.players[_game.currentPlayerIndex].playerName;

            // Update the turns label
            turns.Text = $"{currentPlayerName}s Turn";
        }

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}
    }

}
