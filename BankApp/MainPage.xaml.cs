using BankApp.ViewModels;

namespace BankApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ViewPlayersModel();
        }

        async void OnDoublesButtonClicked(object sender, EventArgs e)
        {
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

        private void OnOpenFlyoutButtonClicked(object sender, EventArgs e)
        {
            // Set the FlyoutIsPresented property to true to display the flyout
            Shell.Current.FlyoutIsPresented = true;
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
