using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Appointment
    {
        private int appointmentId;
        private int KorisnikId;
        private DateTime dateTime;
        private int sumCena;
        private bool state;
        private string employeeName;

        private List<int> appointmentIdList;
        public Appointment(int appointmentId, int korisnikId, DateTime dateTime, int sumCena, bool state, string employeeName, List<int> appointmentIdList)
        {
            this.appointmentId = appointmentId;
            KorisnikId = korisnikId;
            this.dateTime = dateTime;
            this.sumCena = sumCena;
            this.state = state;
            this.employeeName = employeeName;
            this.appointmentIdList = appointmentIdList;
        }

        public int AppointmentId { get => appointmentId; set => appointmentId = value; }
        public int KorisnikId1 { get => KorisnikId; set => KorisnikId = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public int SumCena { get => sumCena; set => sumCena = value; }
        public bool State { get => state; set => state = value; }
        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public List<int> AppointmentIdList { get => appointmentIdList; set => appointmentIdList = value; }

        public override bool Equals(object? obj)
        {
            return obj is Appointment appointment &&
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
    }
}
