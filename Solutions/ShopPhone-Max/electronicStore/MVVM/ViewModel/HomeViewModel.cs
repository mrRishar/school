using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using electronicStore.WPF.Core;
using Microsoft.Extensions.DependencyInjection;

namespace electronicStore.WPF.MVVM.ViewModel
{
    class HomeViewModel : ObservableObject
    {
        public HomeViewModel(IServiceProvider serviceProvider)
        {
            ProductCommand = new RelayCommand(f =>
            {
                var productViewModel = serviceProvider.GetRequiredService<ProductViewModel>();
                productViewModel.ProductName = $"product {DateTime.Now.Second}";

                var mainViewModel = serviceProvider.GetRequiredService<MainViewModel>();
                mainViewModel.CurrentView = productViewModel;
            });
        }

        private string _category = "Home";
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                if (string.Equals(value, _category, StringComparison.CurrentCulture))
                {
                    return;
                }
                _category = value;

                OnPropertyChanged();
            }
        }

        public RelayCommand ProductCommand { get; set; }

    }
}