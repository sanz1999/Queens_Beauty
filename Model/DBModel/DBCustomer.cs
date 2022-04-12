using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DBModel
{
    public class DBCustomer
    {
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public int points { get; set; }
        public int loyaltyNumber { get; set; }

        public DBCustomer(int id, string name, string surname, string phoneNumber, string email, string gender, int points, int loyaltyNumber)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.gender = gender;
            this.points = points;
            this.loyaltyNumber = loyaltyNumber;
        }

        public DBCustomer(string name, string surname, string phoneNumber, string email, string gender, int points, int loyaltyNumber)
        {
            this.name = name;
            this.surname = surname;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.gender = gender;
            this.points = points;
            this.loyaltyNumber = loyaltyNumber;
        }

        public static string GetHeader()
        {
            return string.Format("\n{0, -12} {1, -20} {2, -20} {3, -12} {4, -20} {5, -12} {6, -12} {7, -12}",
                "ID", "NAME", "SURNAME", "PHONE_NUMBER", "EMAIL", "GENDER", "POINTS", "LOYALTY_NUM");
        }

        public override string ToString()
        {

            return string.Format("{0, -12} {1, -20} {2, -20} {3, -12} {4, -20} {5, -12} {6, -12} {7, -12}",
                id, name, surname, phoneNumber, email, gender, points, loyaltyNumber);
        }
    }
}
