using electronicStore.WPF.Core;

namespace electronicStore.WPF.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            CurrentView = HomeVM;

            CategoryCommand = new RelayCommand(f =>
            {
                HomeVM.Category = "1";
            });
        }

        public HomeViewModel HomeVM { get; set; }
        public RelayCommand CategoryCommand { get; set; }

        private object _currentView;
        public object CurrentView
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
