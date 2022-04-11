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
        private int appointmentItemId;
        private int serviceId;

        public AppointmentItemFront(int appointmentItemId, int serviceId)
        {
            this.appointmentItemId = appointmentItemId;
            this.serviceId = serviceId;
        }

        public int AppointmentItemId {
            get { return appointmentItemId; }
            set
            {
                if (appointmentItemId != value)
                {
                    appointmentItemId = value;
                    RaisePropertyChanged("AppointmentItemId");
                }
            }
        }
        public int ServiceId {
            get { return serviceId; }
            set
            {
                if (serviceId != value)
                {
                    serviceId = value;
                    RaisePropertyChanged("ServiceId");
                }
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is AppointmentItemFront item &&
                   appointmentItemId == item.appointmentItemId &&
                   serviceId == item.serviceId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(appointmentItemId, serviceId);
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
