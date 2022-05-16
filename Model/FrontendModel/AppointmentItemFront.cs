using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.FrontendModel
{
    public class AppointmentItemFront : INotifyPropertyChanged
    {
        private ServiceFront service = new ServiceFront();
        private EmployeeFront employee = new EmployeeFront();
        private double price;
        private bool paymentMethod; // false - money; true - points

        public AppointmentItemFront()
        {
        }

        public AppointmentItemFront(ServiceFront service, EmployeeFront employee)
        {
            this.Service = service;
            this.Employee = employee;
        }

        public AppointmentItemFront(ServiceFront service, EmployeeFront employee,double value, bool method)
        {
            this.Service = service;
            this.Employee = employee;
            this.price = value;
            this.paymentMethod = method;
        }

        public ServiceFront Service
        {
            get { return service; }
            set
            {
                if (service != value)
                {
                    service = value;
                    RaisePropertyChanged("Service");
                }
            }
        }
        public EmployeeFront Employee
        {
            get { return employee; }
            set
            {
                if (employee != value)
                {
                    employee = value;
                    RaisePropertyChanged("Employee");
                }
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    RaisePropertyChanged("Price");
                }
            }
        }
        public bool PaymentMethod
        {
            get { return paymentMethod; }
            set
            {
                if (paymentMethod != value)
                {
                    paymentMethod = value;
                    RaisePropertyChanged("PaymentMethod");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override bool Equals(object? obj)
        {
            return obj is AppointmentItemFront front &&
                   EqualityComparer<ServiceFront>.Default.Equals(Service, front.Service) &&
                   EqualityComparer<EmployeeFront>.Default.Equals(Employee, front.Employee);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Service, Employee);
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
