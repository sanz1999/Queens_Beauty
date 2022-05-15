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
        public void ClearInput()
        {
            StartDate = "";
            EndDate = "";
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
                //Should be later
                try
                {
                    if (!CompareDates(appointment.AppointmentDate, DateOnly.Parse(StartDate), true) && !StartDate.Equals(""))
                        return false;
                    else if (StartDate.Equals(""))
                        return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            if (EndDate != null)
                //Should be earlier
                try
                {
                    if (CompareDates(appointment.AppointmentDate, DateOnly.Parse(EndDate), false) && !EndDate.Equals(""))
                        return false;
                    else if (EndDate.Equals(""))
                        return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            return true;
        }
        private bool CompareDates(DateOnly appointmentDate, DateOnly targetDate, bool indicator)
        {
            //indicator is here in order to include both the start date and end date in the search.
            int res = appointmentDate.CompareTo(targetDate);

            //appDate earlier than targetDate
            if (res < 0)
                return false;
            //appDate same as targetDate
            else if (res == 0)
            {
                if (indicator)
                {
                    return true;
                }
                else if (!indicator)
                {
                    return false;
                }
            }
            //appDate later than targetDate
            return true;
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
                    catch (Exception e)
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
