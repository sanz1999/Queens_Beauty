using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels.AppointmentViewModels
{
    public class AppointmentInfoViewModel : AppointmentBindableBase
    {
        private CustomerFront customerVM;
        private string appointmentDateVM;
        private string startTimeVM;
        private string endTimeVM;
        private bool stateVM;
        private string sumCenaVM;

        public BindingList<ServiceFront> ServiceList { get; set; }

        private ServiceFront selectedService;

        public AppointmentInfoViewModel()
        {
            
        }
        internal void ClearInput()
        {
            CustomerVM = null;
            AppointmentDateVM = "";
            StartTimeVM = "";
            EndTimeVM = "";
            StateVM = false;
            ServiceList.Clear();
        }

        public CustomerFront CustomerVM
        {
            get { return customerVM; }
            set
            {
                if (customerVM != value)
                {
                    customerVM = value;
                    OnPropertyChanged("CustomerVM");
                }
            }
        }
        public string AppointmentDateVM
        {
            get { return appointmentDateVM; }
            set
            {
                if (appointmentDateVM != value)
                {
                    appointmentDateVM = value;
                    OnPropertyChanged("AppointmentDateVM");
                }
            }
        }
        public string StartTimeVM
        {
            get { return startTimeVM; }
            set
            {
                if (startTimeVM != value)
                {
                    startTimeVM = value;
                    OnPropertyChanged("StartTimeVM");
                }
            }
        }
        public string EndTimeVM
        {
            get { return endTimeVM; }
            set
            {
                if (endTimeVM != value)
                {
                    endTimeVM = value;
                    OnPropertyChanged("EndTimeVM");
                }
            }
        }

        public bool StateVM
        {
            get { return stateVM; }
            set
            {
                if (stateVM != value)
                {
                    stateVM = value;
                    OnPropertyChanged("StateVM");
                }
            }
        }

        public string SumCenaVM
        {
            get { return sumCenaVM; }
            set
            {
                if (sumCenaVM != value)
                {
                    sumCenaVM = value;
                    OnPropertyChanged("SumCenaVM");
                }
            }
        }
        public ServiceFront SelectedService
        {
            get { return selectedService; }
            set
            {
                if (selectedService != value)
                {
                    selectedService = value;
                    OnPropertyChanged("SelectedService");
                }
            }
        }
    }
}
