using BankApp.Services;

namespace BankApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            var services = new ServiceCollection();
            ConfigureServices(services);

        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<GameService>();

            var serviceProvider = services.BuildServiceProvider();
            ServiceProvider = serviceProvider;
        }

        public static IServiceProvider ServiceProvider { get; private set; }
    }
}
