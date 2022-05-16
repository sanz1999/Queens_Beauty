using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.FrontendModel
{
    public class ServiceFront : INotifyPropertyChanged
    {

        private int id;
        private string name;
        private string category;
        private int duration;
        private double price;
        private int pointsPrice;
        private int pointsValue;
        private int exists;

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }
        public int Exists
        {
            get { return exists; }
            set
            {
                if (exists != value)
                {
                    exists = value;
                    RaisePropertyChanged("Exists");
                }
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        public string Category
        {
            get { return category; }
            set
            {
                if (category != value)
                {
                    category = value;
                    RaisePropertyChanged("Category");
                }
            }
        }
        public int Duration
        {
            get { return duration; }
            set
            {
                if (duration != value)
                {
                    duration = value;
                    RaisePropertyChanged("Duration");
                }
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    RaisePropertyChanged("Price");
                }
            }
        }
        public int PointsPrice
        {
            get { return pointsPrice; }
            set
            {
                if (pointsPrice != value)
                {
                    pointsPrice = value;
                    RaisePropertyChanged("PointsPrice");
                }
            }
        }
        public int PointsValue
        {
            get { return pointsValue; }
            set
            {
                if (pointsValue != value)
                {
                    pointsValue = value;
                    RaisePropertyChanged("PointsValue");
                }
            }
        }

        public ServiceFront() { }

        public ServiceFront(int id, string name, string category, int duration, double price, int pointsPrice, int pointsValue)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Duration = duration;
            this.Price = price;
            this.PointsPrice = pointsPrice;
            this.PointsValue = pointsValue;
        }
        public ServiceFront(int id, string name, string category, int duration, double price, int pointsPrice, int pointsValue,int exists)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Duration = duration;
            this.Price = price;
            this.PointsPrice = pointsPrice;
            this.PointsValue = pointsValue;
            this.exists = exists;
        }
        /*
        public ServiceFront(string name, string category, int duration, double price, int pointsPrice, int pointsValue)
        {
            Id = 0;
            this.Name = name;
            this.Category = category;
            this.Duration = duration;
            this.Price = price;
            this.PointsPrice = pointsPrice;
            this.PointsValue = pointsValue;
        }*/
        public static string GetHeader()
        {
            return string.Format("\n{0, -12} {1, -12} {2, -12} {3, -12} {4, -12} {5, -12} {6, -12}",
                "S_ID", "S_NAME", "S_CATEGORY", "S_DURATION", "S_PRICE", "SP_PRICE", "SP_VALUE");
        }
        public override string ToString()
        {

            return string.Format("{0, -12} {1, -12} {2, -12} {3, -12} {4, -12} {5, -12} {6, -12}", Id, Name, Category, Duration, Price, PointsPrice, PointsValue);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is ServiceFront front &&
                   id == front.id &&
                   name == front.name &&
                   category == front.category &&
                   duration == front.duration &&
                   price == front.price &&
                   pointsPrice == front.pointsPrice &&
                   pointsValue == front.pointsValue &&
                   exists == front.exists;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, name, category, duration, price, pointsPrice, pointsValue, exists);
        }
    }
}
