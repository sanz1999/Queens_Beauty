using Model.DBModel;
using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Methods.TransformSubclasses
{
    public class FEtoDB
    {
        public DBCustomer Customer(CustomerFront utc) {
            string genderdecide = "";
            if (utc.Gender == "Male") {
                genderdecide = "M";
            }
            else if (utc.Gender == "Female") {
                genderdecide = "F";
            }
            else if (utc.Gender == "Other") {
                genderdecide = "O";
            }
            else { 
                genderdecide = "U";
            }
            int loyalID;
            int.TryParse(utc.LoyaltyCardId, out loyalID);

            return new DBCustomer(  utc.CustomerId,
                                    utc.FirstName, 
                                    utc.LastName,
                                    Convert.ToDateTime( utc.DateOfBirth),
                                    utc.PhoneNumber, 
                                    utc.Email, 
                                    genderdecide, 
                                    utc.Points, 
                                    loyalID,
                                    utc.Exists);
        }
        public DBService Service(ServiceFront untrasformedService)
        {
            return new DBService(   untrasformedService.Id,
                                    untrasformedService.Name,
                                    untrasformedService.Category,
                                    untrasformedService.Duration,   
                                    untrasformedService.Price,
                                    untrasformedService.PointsPrice,
                                    untrasformedService.PointsValue,
                                    untrasformedService.Exists
                                    );
        }

        public DBAppointment Appointment(AppointmentFront app) {
            TimeOnly timeOnly = TimeStringToOnlyTime(app.StartTime );
            DateTime termin = new DateTime(app.AppointmentDate.Year, app.AppointmentDate.Month, app.AppointmentDate.Day,timeOnly.Hour,timeOnly.Minute,timeOnly.Second);

            return new DBAppointment(app.AppointmentId, app.Customer.CustomerId, termin, app.SumCena, (app.State) ? 1:0) ;
            
        }

        public TimeOnly TimeStringToOnlyTime(string time) { 
            int hour,minute, second=0,index=time.IndexOf(":");
            hour = Convert.ToInt32(time.Substring(0,index));
            minute = Convert.ToInt32(time.Substring(index+1,2));
            second = 0;
            return new TimeOnly(hour, minute, second);
        }

        public DBSIA AppointmentItem(Tuple<int, AppointmentItemFront> SIA ) {
            DBSIA x = new DBSIA();
            x.id = new Tuple<int, int>(SIA.Item1,SIA.Item2.Service.Id);
            x.workerId = SIA.Item2.Employee.EmployeeId;
            x.value = SIA.Item2.Price;
            if (SIA.Item2.PaymentMethod) { x.method = "p"; }
            else { x.method = "c"; }
            return x;

        }
    }

}