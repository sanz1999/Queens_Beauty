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
        public CustomerFront Customer(DBCustomer untrasformedCustomer)
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
        public ServiceFront Service(DBService untrasformedService)
        {
            return new ServiceFront(untrasformedService.id, untrasformedService.name, untrasformedService.category, untrasformedService.duration, untrasformedService.price, untrasformedService.pointsPrice, untrasformedService.pointsValue,untrasformedService.exists);
        }
    }
}
