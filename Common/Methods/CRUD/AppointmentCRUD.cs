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
                List<DBSIA> dBSIAs = new List<DBSIA>();
                dBSIAs.Clear();
            }

            return newlist;
        }

        public void AddToDataBase(AppointmentFront appointment) { 
        }

        public AppointmentFront FindLastAdded() {
            AppointmentFront last = new AppointmentFront();
            return last;
        }

        public void DeleteFromDataBase(AppointmentFront appointment) { 
        }

        public void UpdateInDataBase(AppointmentFront appointment) { 
        }
    }
}
