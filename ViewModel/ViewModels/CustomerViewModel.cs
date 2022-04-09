using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModels.CustomerViewModels;

namespace ViewModel.ViewModels
{
    public class CustomerViewModel : BindableBase
    {
        private CustomerAddViewModel customerAddViewModel = new CustomerAddViewModel();
        private CustomerFilterViewModel customerFilterViewModel = new CustomerFilterViewModel();
        private CustomerInfoViewModel customerInfoViewModel = new CustomerInfoViewModel();
        private BindableBase currentCustomerViewModel;

        public MyICommand<string> NavCommand { get; set; }
        public CustomerViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentCustomerViewModel = customerFilterViewModel;
        }

        private void OnNav(string obj)
        {
            switch (obj)
            {
                case "add":
                    CurrentCustomerViewModel = customerAddViewModel;
                    break;
                case "filter":
                    CurrentCustomerViewModel = customerFilterViewModel;
                    break;
                case "info":
                    CurrentCustomerViewModel = customerInfoViewModel;
                    break;
            }
        }

        public BindableBase CurrentCustomerViewModel
        {
            get { return currentCustomerViewModel; }
            set
            {
                SetProperty(ref currentCustomerViewModel, value);
            }
        }
    }
}
