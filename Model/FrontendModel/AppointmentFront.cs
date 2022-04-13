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
        private int korisnikId;
        private DateOnly appointmentDate;
        private string startTime;
        private string endTime;
        private int sumCena;
        private bool state;
        private string employeeName;

        private List<int> appointmentIdList;

        public AppointmentFront(int appointmentId, int korisnikId, DateOnly appointmentDate, string startTime, string endTime, int sumCena, bool state, string employeeName, List<int> appointmentIdList)
        {
            this.appointmentId = appointmentId;
            this.korisnikId = korisnikId;
            this.appointmentDate = appointmentDate;
            this.StartTime = startTime;
            this.EndTime = endTime;
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
            get { return korisnikId; }
            set
            {
                if (korisnikId != value)
                {
                    korisnikId = value;
                    RaisePropertyChanged("KorisnikId");
                }
            }
        }
        public DateOnly AppointmentDate
        {
            get { return appointmentDate; }
            set
            {
                if (appointmentDate != value)
                {
                    appointmentDate = value;
                    RaisePropertyChanged("AppointmentDate");
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
            } 
        }
        public string StartTime
        {
            get { return startTime; }
            set
            {
                if (startTime != value)
                {
                    startTime = value;
                    RaisePropertyChanged("StartTime");
                }
            }
        }
        public string EndTime
        {
            get { return endTime; }
            set
            {
                if (endTime != value)
                {
                    endTime = value;
                    RaisePropertyChanged("EndTime");
                }
            }
        }
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


        
        public event PropertyChangedEventHandler? PropertyChanged;

        public override bool Equals(object? obj)
        {
            return obj is AppointmentFront front &&
                   appointmentId == front.appointmentId &&
                   korisnikId == front.korisnikId &&
                   appointmentDate.Equals(front.appointmentDate) &&
                   startTime == front.startTime &&
                   endTime == front.endTime &&
                   sumCena == front.sumCena &&
                   state == front.state &&
                   employeeName == front.employeeName &&
                   EqualityComparer<List<int>>.Default.Equals(appointmentIdList, front.appointmentIdList);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(appointmentId);
            hash.Add(korisnikId);
            hash.Add(appointmentDate);
            hash.Add(startTime);
            hash.Add(endTime);
            hash.Add(sumCena);
            hash.Add(state);
            hash.Add(employeeName);
            hash.Add(appointmentIdList);
            return hash.ToHashCode();
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
