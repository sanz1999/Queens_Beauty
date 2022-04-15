using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DBModel
{
    public class DBAppointment
    {
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
        public int appointmentId { get; set; }
        public int customerId { get; set; }
        public DateTime dateTime { get; set; }
        public double price { get; set; }
        public int state { get; set; }
        public int exists { get; set; }

        //Koristi se za preuzimanje svih podataka radi ispisa
        public DBAppointment(int appointmentId, int customerId, DateTime dateTime, double price, int state, int exists)
        {
            this.appointmentId = appointmentId;
            this.customerId = customerId;
            this.dateTime = dateTime;
            this.price = price;
            this.state = state;
            this.exists = exists;
        }

        //Koristi se za pravljenje Appointment-a sa poznatim id-em
        public DBAppointment(int appointmentId, int customerId, DateTime dateTime, double price)
        {
            this.appointmentId = appointmentId;
            this.customerId = customerId;
            this.dateTime = dateTime;
            this.price = price;
        }

        //Korisit se za pravljenje Appointment-a kojem ce se id dodeliti automatski
        public DBAppointment(int customerId, DateTime dateTime, double price)
        {
            appointmentId = 0;
            this.customerId = customerId;
            this.dateTime = dateTime;
            this.price = price;
        }

        public static string GetHeader()
        {
            return string.Format("\n{0, -12} {1, -12} {2, -20} {3, -12} {4, -12}",
                "AID", "CID", "DateTime", "Price", "STATE");
        }
        public override string ToString()
        {
            return string.Format("{0, -12} {1, -12} {2, -20:H:mm dd/MM/yy} {3, -12} {4, -12}",
                appointmentId, customerId, dateTime, price, state);
        }
    }
}
