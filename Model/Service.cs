using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Service
    {
        private int serviceId;
        private string name;
        private int price;
        private int duration; // In minutes.
        private int pointPrice;
        private int pointReward;
        private string category;

        public Service(int serviceId, string name, int price, int duration, int pointPrice, int pointReward, string category)
        {
            this.serviceId = serviceId;
            this.name = name;
            this.price = price;
            this.duration = duration;
            this.pointPrice = pointPrice;
            this.pointReward = pointReward;
            this.category = category;
        }

        public int ServiceId { get => serviceId; set => serviceId = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public int Duration { get => duration; set => duration = value; }
        public int PointPrice { get => pointPrice; set => pointPrice = value; }
        public int PointReward { get => pointReward; set => pointReward = value; }
        public string Category { get => category; set => category = value; }

        public override bool Equals(object? obj)
        {
            return obj is Service service &&
                   serviceId == service.serviceId &&
                   name == service.name &&
                   price == service.price &&
                   duration == service.duration &&
                   pointPrice == service.pointPrice &&
                   pointReward == service.pointReward &&
                   category == service.category;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(serviceId, name, price, duration, pointPrice, pointReward, category);
        }
    }
}
