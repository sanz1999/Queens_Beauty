using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DBModel
{
    public class DBAppointment
    {
        public int appointmentId { get; set; }
        public int customerId { get; set; }
        public DateTime dateTime { get; set; }
        public double price { get; set; }
        public int state { get; set; }

        public DBAppointment(int appointmentId, int customerId, DateTime dateTime, double price, int state)
        {
            this.appointmentId = appointmentId;
            this.customerId = customerId;
            this.dateTime = dateTime;
            this.price = price;
            this.state = state;
        }

        public DBAppointment(int customerId, DateTime dateTime, double price, int state)
        {
            this.customerId = customerId;
            this.dateTime = dateTime;
            this.price = price;
            this.state = state;
        }

        public static string GetHeader()
        {
            return string.Format("\n{0, -12} {1, -12} {2, -12} {3, -12} {4, -12}",
                "AID", "CID", "DateTime", "Price", "STATE");
        }
        public override string ToString()
        {
            return string.Format("{0, -12} {1, -12} {2, -12} {3, -12} {4, -12}",
                appointmentId, customerId, dateTime, price, state);
        }
    }
}
