using System;
using System.Windows.Controls;
using electronicStore.WPF.Core;
using Microsoft.Extensions.DependencyInjection;

namespace electronicStore.WPF.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        IServiceProvider _serviceProvider;
        public MainViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            CurrentView = serviceProvider.GetRequiredService<HomeViewModel>();
        }

        public RelayCommand CategoryCommand { get; set; }

        public void SetHomeView(string name)
        {
            var homeVm = _serviceProvider.GetRequiredService<HomeViewModel>();
            homeVm.Category = name;

            CurrentView = homeVm;
        }


        private ObservableObject _currentView;
        public ObservableObject CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
    }
}
