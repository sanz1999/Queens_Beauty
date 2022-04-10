using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DBService
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public int duration { get; set; }
        public double price { get; set; }
        public int pointsPrice { get; set; }
        public int pointsValue { get; set; }

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
            return string.Format("\n{0, -12} {1, -12} {2, -12} {3, -12} {4, -12} {5, -12} {6, -12}",
                "S_ID", "S_NAME", "S_CATEGORY", "S_DURATION", "S_PRICE", "SP_PRICE", "SP_VALUE");
        }
        public override string ToString()
        {

            return string.Format("{0, -12} {1, -12} {2, -12} {3, -12} {4, -12} {5, -12} {6, -12}",
                id, name, category, duration, price, pointsPrice, pointsValue);
        }
    }
}