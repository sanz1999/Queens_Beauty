using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private StartupViewModel startupViewModel = new StartupViewModel();
        private ServiceViewModel serviceViewModel = new ServiceViewModel();
        private CustomerViewModel customerViewModel = new CustomerViewModel();
        private AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
        private BindableBase currentViewModel;
        
        public MyICommand<string> NavCommand { get; set; }
        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = startupViewModel;
        }

        private void OnNav(string obj)
        {
            switch (obj)
            {
                case "customer":
                    CurrentViewModel = customerViewModel;
                    break;
                case "service":
                    CurrentViewModel = serviceViewModel;
                    break;
                case "appointment":
                    CurrentViewModel = appointmentViewModel;
                    break;
            }
        }
       
        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }
    }
}
