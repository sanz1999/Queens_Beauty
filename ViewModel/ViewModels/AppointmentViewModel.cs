using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModels.AppointmentViewModels;

namespace ViewModel.ViewModels
{
    public class AppointmentViewModel : BindableBase
    {
        private AppointmentAddViewModel appointmentAddViewModel = new AppointmentAddViewModel();
        private AppointmentFilterViewModel appointmentFilterViewModel = new AppointmentFilterViewModel();
        private AppointmentInfoViewModel appointmentInfoViewModel = new AppointmentInfoViewModel();
        private BindableBase currentAppointmentViewModel;

        public MyICommand<string> NavCommand { get; set; }
        public AppointmentViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentAppointmentViewModel = appointmentFilterViewModel;
        }

        private void OnNav(string obj)
        {
            switch (obj)
            {
                case "add":
                    CurrentAppointmentViewModel = appointmentAddViewModel;
                    break;
                case "filter":
                    CurrentAppointmentViewModel = appointmentFilterViewModel;
                    break;
                case "info":
                    CurrentAppointmentViewModel = appointmentInfoViewModel;
                    break;
                case "alter":
                    CurrentAppointmentViewModel = appointmentAddViewModel;
                    break;
            }
        }

        public BindableBase CurrentAppointmentViewModel
        {
            get { return currentAppointmentViewModel; }
            set
            {
                SetProperty(ref currentAppointmentViewModel, value);
            }
        }
    }
}
