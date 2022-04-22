using DatabaseLogic.Services;
using Model.DBModel;
using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public  AppointmentFront Appointment(DBAppointment utapp, List<Tuple<int, int>> ursia) {
            AppointmentFront app = new AppointmentFront();
            app.AppointmentId = utapp.appointmentId;
            app.Customer =  Customer(customerService.FindById(utapp.customerId)); //find customer
            app.AppointmentDate =  DateOnly.FromDateTime(utapp.dateTime);
            app.StartTime = TimeOnly.FromDateTime(utapp.dateTime).ToString();
            app.EndTime = TimeOnly.FromDateTime(utapp.dateTime).ToString(); // Izracunati nekako
            app.SumCena = utapp.price;
            app.State = (utapp.state == 1) ? true:false ;
            app.SIA = AppointmentItems(ursia);
            return app;
        }

  

        public  BindingList<AppointmentItemFront> AppointmentItems(List<Tuple<int, int>> dba)
        {
             BindingList<AppointmentItemFront> aitem = new BindingList<AppointmentItemFront>();
            foreach (Tuple<int, int> d in dba) {
                AppointmentItemFront aitemx = new AppointmentItemFront();
                aitemx.Service = Service(serviceService.FindById(d.Item1));
                aitemx.Employee = Employee(workerService.FindById(d.Item2));
                aitem.Add(aitemx);
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
