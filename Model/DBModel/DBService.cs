using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DBModel
{
    public class DBService
    {
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public int duration { get; set; }
        public double price { get; set; }
        public int pointsPrice { get; set; }
        public int pointsValue { get; set; }
        public int exists { get; set; }

        //Koristi se za preuzimanje svih podataka radi ispisa
        public DBService(int id, string name, string category, int duration, double price, int pointsPrice, int pointsValue, int exists)
        {
            this.id = id;
            this.name = name;
            this.category = category;
            this.duration = duration;
            this.price = price;
            this.pointsPrice = pointsPrice;
            this.pointsValue = pointsValue;
            this.exists = exists;
        }

        //Koristi se za pravljenje Service-a sa poznatim id-em
        public DBService(int id, string name, string category, int duration, double price, int pointsPrice, int pointsValue)
        {
            this.id = id;
            this.name = name;
            this.category = category;
            this.duration = duration;
            this.price = price;
            this.pointsPrice = pointsPrice;
            this.pointsValue = pointsValue;            
        }
        
        //Korisit se za pravljenje Service-a kojem ce se id dodeliti automatski
        public DBService(string name, string category, int duration, double price, int pointsPrice, int pointsValue)
        {
            id = 0;
            this.name = name;
            this.category = category;
            this.duration = duration;
            this.price = price;
            this.pointsPrice = pointsPrice;
            this.pointsValue = pointsValue;            
        }

        public static string GetHeader()
        {
            return string.Format("\n{0, -12} {1, -12} {2, -12} {3, -12} {4, -12} {5, -12} {6, -12} {7, -12}",
                "S_ID", "S_NAME", "S_CATEGORY", "S_DURATION", "S_PRICE", "SP_PRICE", "SP_VALUE", "EXISTS");
        }
        public override string ToString()
        {
          return string.Format("{0, -12} {1, -12} {2, -12} {3, -12} {4, -12} {5, -12} {6, -12} {7, -12}",
                id, name, category, duration, price, pointsPrice, pointsValue, exists);            
        }
    }
}