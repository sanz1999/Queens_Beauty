using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels.ServiceViewModels
{
    public class ServiceFilterViewModel : BindableBase
    {
        private string nameVM;
        private object categoryVM;
        public BindingList<string> Categories { get; set; }
        public ServiceFilterViewModel()
        {
        }
        public void ClearInput()
        {
            NameVM = "";
            CategoryVM = null;
        }
        public string NameVM
        {
            get { return nameVM; }
            set
            {
                if (nameVM != value)
                {
                    nameVM = value;
                    OnPropertyChanged("NameVM");
                }
            }
        }
        public object CategoryVM
        {
            get { return categoryVM; }
            set
            {
                if (categoryVM != value)
                {
                    categoryVM = value;
                    OnPropertyChanged("CategoryVM");
                }
            }
        }
    }
}
