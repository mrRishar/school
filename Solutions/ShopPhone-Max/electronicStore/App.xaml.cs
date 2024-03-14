using System.Configuration;
using System.Data;
using System.Windows;

namespace electronicStore
{
    public partial class App : Application
    {
        private readonly IServiceCollection serviceCollection = new ServiceCollection();

        public App()
        {
            
        }
    }
}