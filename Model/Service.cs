using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Service
    {
        private int id;
        private string name;
        private string category;
        private int duration;
        private double price;
        private int pointsPrice;
        private int pointsValue;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public int Duration { get => duration; set => duration = value; }
        public double Price { get => price; set => price = value; }
        public int PointsPrice { get => pointsPrice; set => pointsPrice = value; }
        public int PointsValue { get => pointsValue; set => pointsValue = value; }

        public Service() { }

        public Service(int id, string name, string category, int duration, double price, int pointsPrice, int pointsValue)
        {
            this.id = id;
            this.name = name;
            this.category = category;
            this.duration = duration;
            this.price = price;
            this.pointsPrice = pointsPrice;
            this.pointsValue = pointsValue;
        }

        public Service(string name, string category, int duration, double price, int pointsPrice, int pointsValue)
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

            return string.Format("{0, -12} {1, -12} {2, -12} {3, -12} {4, -12} {5, -12} {6, -12}", id, name, category, duration, price, pointsPrice, pointsValue);
        }
    }
}