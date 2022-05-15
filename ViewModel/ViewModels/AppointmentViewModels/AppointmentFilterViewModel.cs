using Model.FrontendModel;
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
            Appointments = new BindingList<AppointmentFront>();
            AppointmentsSearch = new BindingList<AppointmentFront>();
        }
        private void Filter()
        {
            bool canAdd;
            AppointmentsSearch.Clear();
            foreach (AppointmentFront appointment in Appointments)
            {
                canAdd = CanAppointmentPassFilter(appointment);
                if (canAdd)
                    AppointmentsSearch.Add(appointment);
            }
        }

        private bool CanAppointmentPassFilter(AppointmentFront appointment)
        {
            if (StartDate != null)
                try
                {
                    if (!CompareDate(appointment.AppointmentDate, DateOnly.Parse(StartDate), 0))
                        return false;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            if (EndDate != null)
                try
                {
                    if (CompareDate(appointment.AppointmentDate, DateOnly.Parse(EndDate), 1))
                        return false;
                }
                catch(Exception e){
                    Console.WriteLine(e.Message);
                }
            return true;
        }

        private bool CompareDate(DateOnly appointmentDate, DateOnly date, int indicator)
        {
            //indicator - 0 if StartDate, 1 if EndDate - in order to include []
            
            //earlier
            if(appointmentDate.CompareTo(date) < 0)
            {
                return false;
            }
            //later
            else if(appointmentDate.CompareTo(date) > 0)
            {
                return true;
            }
            else
            {
                if(indicator == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
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
                    try
                    {
                        if (!StartDate.Equals(""))
                            DateOnly.Parse(StartDate);
                        Filter();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
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
                    try
                    {
                        if (!EndDate.Equals(""))
                            DateOnly.Parse(EndDate);
                        Filter();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    OnPropertyChanged("EndDate");
                }
            }
        }
    }
}
