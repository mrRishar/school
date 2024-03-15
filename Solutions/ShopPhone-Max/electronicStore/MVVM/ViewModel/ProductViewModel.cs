using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using electronicStore.WPF.Core;

namespace electronicStore.WPF.MVVM.ViewModel
{
    class ProductViewModel : ObservableObject
    {
        public string ProductName { get; set; } = "Items 1";
    }
}