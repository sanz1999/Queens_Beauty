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

            return new DBCustomer(utc.CustomerId, utc.FirstName, utc.LastName, utc.PhoneNumber, utc.Email, genderdecide, utc.Points, loyalID);
        }
        public DBService Service(ServiceFront untrasformedService)
        {
            return new DBService(untrasformedService.Id, untrasformedService.Name, untrasformedService.Category, untrasformedService.Duration, untrasformedService.Price, untrasformedService.PointsPrice, untrasformedService.PointsValue);
        }
    }
}
