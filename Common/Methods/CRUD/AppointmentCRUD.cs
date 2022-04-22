using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model.FrontendModel;
using Model.DBModel;
using DatabaseLogic.Services;

namespace Common.Methods.CRUD
{
    public class AppointmentCRUD
    {
        private Transform transform=  new Transform();      
        private AppointmentService appointmentService = new AppointmentService();
        private SIAService sIAService = new SIAService();

        public BindingList<AppointmentFront> LoadFromDataBase() {
            BindingList<AppointmentFront> newlist = new BindingList<AppointmentFront>();
            List<DBAppointment> dBAppointments = (List<DBAppointment>)appointmentService.FindAll();
            foreach (DBAppointment app in dBAppointments) { 
                List<Tuple<int,int>> dBSIAs = new List<Tuple<int, int>>();
                dBSIAs.Clear();
                dBSIAs = (List<Tuple<int, int>>)sIAService.GetAllServicesForId(app.appointmentId);
                newlist.Add(transform.DBToFE.Appointment(app, dBSIAs));
            }

            return newlist;
        }

        public void AddToDataBase(AppointmentFront appointment) { 
        }

        public AppointmentFront FindLastAdded() {       // ovo treba implementirati
            AppointmentFront last = new AppointmentFront();
                return last;
        }

        public void DeleteFromDataBase(AppointmentFront appointment) {
         //   appointmentService.Delete(transformm.FEToDB.Appointment(appointment));
        }

        public void UpdateInDataBase(AppointmentFront appointment) { 
        }
    }
}

// ubaciti appointment pa onda sve sia u bazu, ali zato kad se brise samo se brise 
//appointment a stefan ce sve ostalo
