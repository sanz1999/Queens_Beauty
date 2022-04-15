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
        public DateTime dateOfBirth { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public int points { get; set; }
        public int loyaltyNumber { get; set; }
        public int exists { get; set; }
        
        //Koristi se za preuzimanje svih podataka radi ispisa
        public DBCustomer(int id, string name, string surname, DateTime dateOfBirth, string phoneNumber, string email, string gender, int points, int loyaltyNumber, int exists)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.dateOfBirth = dateOfBirth;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.gender = gender;
            this.points = points;
            this.loyaltyNumber = loyaltyNumber;
            this.exists = exists;
        }
        
        //Koristi se za pravljenje Customer-a sa poznatim id-em
        public DBCustomer(int id, string name, string surname, DateTime dateOfBirth, string phoneNumber, string email, string gender, int points, int loyaltyNumber)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.dateOfBirth = dateOfBirth;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.gender = gender;
            this.points = points;
            this.loyaltyNumber = loyaltyNumber;            
        }
        
        //Korisit se za pravljenje Customer-a kojem ce se id dodeliti automatski
        public DBCustomer(string name, string surname, DateTime dateOfBirth, string phoneNumber, string email, string gender, int points, int loyaltyNumber)
        {
            this.id = 0;
            this.name = name;
            this.surname = surname;
            this.dateOfBirth = dateOfBirth;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.gender = gender;
            this.points = points;
            this.loyaltyNumber = loyaltyNumber;            
        }

        public static string GetHeader()
        {
            return string.Format("\n{0, -12} {1, -20} {2, -20} {3, -12} {4, -20} {5, -20} {6, -6} {7, -12} {8, -12} {9, -12}",
                "ID", "NAME", "SURNAME","BDY", "PHONE_NUMBER", "EMAIL", "GENDER", "POINTS", "LOYALTY_NUM", "EXISTS");
        }

        public override string ToString()
        {

            return string.Format("{0, -12} {1, -20} {2, -20} {3, -12:dd/MM/yy} {4, -20} {5, -20} {6, -6} {7, -12} {8, -12} {9, -12}",
                id, name, surname,dateOfBirth, phoneNumber, email, gender, points, loyaltyNumber, exists);
        }
    }
}
