using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels.AppointmentViewModels
{
    public class AppointmentFilterViewModel : BindableBase
    {
        private string appointmentDateVM;

        private bool isDayVM;
        private bool isWeekVM;
        private bool isMonthVM;
        public AppointmentFilterViewModel()
        {
        }

        public void ClearInput()
        {
            AppointmentDateVM = "";
            IsDayVM = false;
            IsWeekVM = false;
            IsMonthVM = false;
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
        public bool IsDayVM
        {
            get { return isDayVM; }
            set
            {
                if (isDayVM != value)
                {
                    isDayVM = value;
                    OnPropertyChanged("IsDayVM");
                }
            }
        }
        public bool IsWeekVM
        {
            get { return isWeekVM; }
            set
            {
                if (isWeekVM != value)
                {
                    isWeekVM = value;
                    OnPropertyChanged("IsWeekVM");
                }
            }
        }
        public bool IsMonthVM
        {
            get { return isMonthVM; }
            set
            {
                if (isMonthVM != value)
                {
                    isMonthVM = value;
                    OnPropertyChanged("IsMonthVM");
                }
            }
        }
    }
}
