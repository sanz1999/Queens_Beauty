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
        public MyICommand TextChangedCommand { get; set; }
        public ServiceFilterViewModel()
        {
            Services = new BindingList<ServiceFront>();
            ServicesSearch = new BindingList<ServiceFront>();

            TextChangedCommand = new MyICommand(OnTextChanged);
        }
        private void OnTextChanged()
        {
            Filter();
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
                if (!service.Name.ToLower().Contains(NameVM.ToLower()) && !NameVM.ToLower().Equals(""))
                    return false;
            if (CategoryVM != null)
                if (!service.Category.ToLower().Contains(CategoryVM.ToString().ToLower()) && !CategoryVM.ToString().ToLower().Equals(""))
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
