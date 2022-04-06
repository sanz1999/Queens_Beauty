using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppointmentItem
    {
        private int appointmentItemId;
        private int serviceId;

        public AppointmentItem(int appointmentItemId, int serviceId)
        {
            this.appointmentItemId = appointmentItemId;
            this.serviceId = serviceId;
        }

        public int AppointmentItemId { get => appointmentItemId; set => appointmentItemId = value; }
        public int ServiceId { get => serviceId; set => serviceId = value; }

        public override bool Equals(object? obj)
        {
            return obj is AppointmentItem item &&
                   appointmentItemId == item.appointmentItemId &&
                   serviceId == item.serviceId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(appointmentItemId, serviceId);
        }
    }
}
