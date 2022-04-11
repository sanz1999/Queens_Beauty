using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.FrontendModel
{
    public class AppointmentFront : INotifyPropertyChanged

    {

        private int appointmentId;
        private int KorisnikId;
        private DateTime dateTime;
        private int sumCena;
        private bool state;
        private string employeeName;

        private List<int> appointmentIdList;
        public AppointmentFront(int appointmentId, int korisnikId, DateTime dateTime, int sumCena, bool state, string employeeName, List<int> appointmentIdList)
        {
            this.appointmentId = appointmentId;
            KorisnikId = korisnikId;
            this.dateTime = dateTime;
            this.sumCena = sumCena;
            this.state = state;
            this.employeeName = employeeName;
            this.appointmentIdList = appointmentIdList;
        }

        public int AppointmentId
        {
            get { return appointmentId; }
            set
            {
                if (appointmentId != value)
                {
                    appointmentId = value;
                    RaisePropertyChanged("AppointmentId");
                }
            }
        }
        public int KorisnikId1
        {
            get { return KorisnikId; }
            set
            {
                if (KorisnikId != value)
                {
                    KorisnikId = value;
                    RaisePropertyChanged("KorisnikId");
                }
            }
        }
        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                if (dateTime != value)
                {
                    dateTime = value;
                    RaisePropertyChanged("DateTime");
                }
            }
        }
        public int SumCena
        {
            get { return sumCena; }
            set
            {
                if (sumCena != value)
                {
                    sumCena = value;
                    RaisePropertyChanged("SumCena");
                }
            } }
        public bool State
        {
            get { return state; }
            set
            {
                if (state != value)
                {
                    state = value;
                    RaisePropertyChanged("State");
                }
            }
        }
        public string EmployeeName
        {
            get { return employeeName; }
            set
            {
                if (employeeName != value)
                {
                    employeeName = value;
                    RaisePropertyChanged("EmployeeName");
                }
            }
        }
        public List<int> AppointmentIdList
        {
            get { return appointmentIdList; }
            set
            {
                if (appointmentIdList != value)
                {
                    appointmentIdList = value;
                    RaisePropertyChanged("AppointmentIdList");
                }
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is AppointmentFront appointment &&
                   appointmentId == appointment.appointmentId &&
                   KorisnikId == appointment.KorisnikId &&
                   dateTime == appointment.dateTime &&
                   sumCena == appointment.sumCena &&
                   state == appointment.state &&
                   employeeName == appointment.employeeName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(appointmentId, KorisnikId, dateTime, sumCena, state, employeeName);
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
