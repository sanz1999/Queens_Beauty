using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels.AppointmentViewModels
{
    public class AppointmentFilterViewModel : AppointmentBindableBase
    {
        private string startDate;
        private string endDate;
        public AppointmentFilterViewModel()
        {
        }

        public void ClearInput()
        {
            StartDate = "";
            EndDate = "";
        }
        public string StartDate
        {
            get { return startDate; }
            set
            {
                if (startDate != value)
                {
                    startDate = value;
                    OnPropertyChanged("StartDate");
                }
            }
        }
        public string EndDate
        {
            get { return endDate; }
            set
            {
                if (endDate != value)
                {
                    endDate = value;
                    OnPropertyChanged("EndDate");
                }
            }
        }
    }
}
