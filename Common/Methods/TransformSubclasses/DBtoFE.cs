using DatabaseLogic.Services;
using Model.DBModel;
using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Methods.TransformSubclasses
{
    public class DBtoFE
    {
        private CustomerService customerService = new CustomerService();
        private ServiceService  serviceService = new ServiceService();
        private WorkerService workerService =  new WorkerService();

        public  CustomerFront Customer(DBCustomer untrasformedCustomer)
        {
            string genderdecide = "";
            if (untrasformedCustomer.gender == "M")
            {
                genderdecide = "Male";
            }
            else if (untrasformedCustomer.gender == "F")
            {
                genderdecide = "Female";
            }
            else if (untrasformedCustomer.gender == "O")
            {
                genderdecide = "Other";
            }
            else
            {
                genderdecide = "Unspecified";
            }
            return new CustomerFront(   untrasformedCustomer.id,
                                        untrasformedCustomer.name,
                                        untrasformedCustomer.surname,
                                        untrasformedCustomer.phoneNumber,
                                        untrasformedCustomer.dateOfBirth.ToShortDateString(),
                                        untrasformedCustomer.email,
                                        genderdecide,
                                        untrasformedCustomer.points,
                                        untrasformedCustomer.loyaltyNumber.ToString(),
                                        untrasformedCustomer.exists
                                        );
        }
        public  ServiceFront Service(DBService untrasformedService)
        {
            return new ServiceFront(    untrasformedService.id, 
                                        untrasformedService.name, 
                                        untrasformedService.category, 
                                        untrasformedService.duration, 
                                        untrasformedService.price, 
                                        untrasformedService.pointsPrice, 
                                        untrasformedService.pointsValue,
                                        untrasformedService.exists
                                        );
        }

        public  AppointmentFront Appointment(DBAppointment utapp, List<DBSIA> ursia) {
            AppointmentFront app = new AppointmentFront();
            app.AppointmentId = utapp.appointmentId;
            app.Customer =  Customer(customerService.FindById(utapp.customerId)); //find customer
            app.AppointmentDate =  DateOnly.FromDateTime(utapp.dateTime);
            app.StartTime = TimeOnly.FromDateTime(utapp.dateTime).ToString();
            app.EndTime = TimeOnly.FromDateTime(utapp.dateTime).ToString(); // Izracunati nekako
            app.SumCena = utapp.price;
            app.State = (utapp.state == 1) ? true:false ;
            app.SIA = (System.ComponentModel.BindingList<AppointmentItemFront>)AppointmentItem(ursia);
            return app;
        }

        public  AppointmentItemFront AppointmentItem(DBSIA dba) {
            AppointmentItemFront aitem = new AppointmentItemFront();
            aitem.Service = Service(serviceService.FindById(dba.id.Item2));
            aitem.Employee = Employee(workerService.FindById(dba.workerId));
            return aitem;

        }

        public  IEnumerable<AppointmentItemFront> AppointmentItem(IEnumerable<DBSIA> dba)
        {
             List<AppointmentItemFront> aitem = new List<AppointmentItemFront>();
            foreach (DBSIA d in dba) { 
                aitem.Add(AppointmentItem(d));
            }
            return aitem;
        }

        public EmployeeFront Employee(DBWorker worker) { 
            EmployeeFront employee = new EmployeeFront();
            employee.EmployeeId = worker.id;
            employee.Name = worker.name;
            return employee;
        }
    }
}
