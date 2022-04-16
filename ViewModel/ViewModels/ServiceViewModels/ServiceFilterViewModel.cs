using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels.ServiceViewModels
{
    public class ServiceFilterViewModel : ServiceBindableBase
    {
        private string nameVM;
        private object categoryVM;
        public BindingList<string> Categories { get; set; }
        public ServiceFilterViewModel()
        {
            Services = new BindingList<ServiceFront>();
            ServicesSearch = new BindingList<ServiceFront>();   
        }
        private void Filter()
        {
            bool canAdd;
            ServicesSearch.Clear();
            foreach (ServiceFront service in Services)
            {
                canAdd = CanServicePassFilter(service);
                if (canAdd)
                    ServicesSearch.Add(service);
            }
        }

        private bool CanServicePassFilter(ServiceFront service)
        {
            if (NameVM != null)
                if (!service.Name.Contains(NameVM) && !NameVM.Equals(""))
                    return false;
            if (CategoryVM != null)
                if (!service.Category.Contains(CategoryVM.ToString()) && !CategoryVM.ToString().Equals(""))
                    return false;
            return true;
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
                    Filter();
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
                    Filter();
                    OnPropertyChanged("CategoryVM");
                }
            }
        }
    }
}
