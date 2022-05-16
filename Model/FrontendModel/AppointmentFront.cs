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
        private CustomerFront customer;
        private DateOnly appointmentDate;
        private string startTime;
        private string endTime;
        private double sumCena;
        private bool state;
        public BindingList<AppointmentItemFront> SIA { get;  set; }
        //public BindingList<Tuple<ServiceFront, EmployeeFront>> SIA { get; private set; }

        public AppointmentFront() {
            this.SIA = new BindingList<AppointmentItemFront>();
        }

        public AppointmentFront(int appointmentId, CustomerFront customer, DateOnly appointmentDate, string startTime, string endTime, double sumCena, bool state,BindingList<AppointmentItemFront> lista)
        {
            this.appointmentId = appointmentId;
            this.customer = customer;
            this.appointmentDate = appointmentDate;
            this.startTime = startTime;
            this.endTime = endTime;
            this.sumCena = sumCena;
            this.state = state;
            this.SIA = lista;
            
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
        public CustomerFront Customer
        {
            get { return customer; }
            set
            {
                if (customer != value)
                {
                    customer = value;
                    RaisePropertyChanged("Customer");
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
        public double SumCena
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

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is AppointmentFront front &&
                   appointmentId == front.appointmentId;  /* &&
                   EqualityComparer<CustomerFront>.Default.Equals(customer, front.customer) &&
                   appointmentDate.Equals(front.appointmentDate) &&
                   startTime == front.startTime &&
                   endTime == front.endTime &&
                   sumCena == front.sumCena &&
                   state == front.state;*/
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(appointmentId, customer, appointmentDate, startTime, endTime, sumCena, state);
        }
    }
}
