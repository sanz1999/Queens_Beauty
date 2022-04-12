using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModels.ServiceViewModels;

namespace ViewModel.ViewModels
{
    public class ServiceViewModel : BindableBase
    {
        private ServiceAddViewModel serviceAddViewModel = new ServiceAddViewModel();
        private ServiceFilterViewModel serviceFilterViewModel = new ServiceFilterViewModel();
        private ServiceInfoViewModel serviceInfoViewModel = new ServiceInfoViewModel();
        private BindableBase currentServiceViewModel;
        public MyICommand<string> NavCommand { get; set; }
        
        public ServiceViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentServiceViewModel = serviceFilterViewModel;
        }

        private void OnNav(string obj)
        {
            switch (obj)
            {
                case "add":
                    CurrentServiceViewModel = serviceAddViewModel;
                    break;
                case "filter":
                    CurrentServiceViewModel = serviceFilterViewModel;
                    break;
                case "info":
                    CurrentServiceViewModel = serviceInfoViewModel;
                    break;
                case "alter":
                    CurrentServiceViewModel = serviceAddViewModel;
                    break;
            }
        }
        public BindableBase CurrentServiceViewModel
        {
            get { return currentServiceViewModel; }
            set
            {
                SetProperty(ref currentServiceViewModel, value);
            }
        }
    }
}
