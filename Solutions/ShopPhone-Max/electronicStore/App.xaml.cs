using System.Windows;
using electronicStore.WPF;
using electronicStore.WPF.MVVM.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace electronicStore
{
    public partial class App : Application
    {
        private readonly IServiceCollection _serviceCollection = new ServiceCollection();
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            _serviceCollection.AddSingleton<MainViewModel>();
            _serviceCollection.AddSingleton<HomeViewModel>();
            _serviceCollection.AddSingleton<ProductViewModel>();

            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWin = new MainWindow(_serviceProvider);
            mainWin.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
            mainWin.Show();

            base.OnStartup(e);
        }
    }
}