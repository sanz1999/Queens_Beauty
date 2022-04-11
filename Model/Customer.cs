using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer : INotifyPropertyChanged
    {
        private int customerId;
        private string firstName;
        private string lastName;
        private int phoneNumber;
        private string email;
        private string gender;
        private int points;
        private int loyaltyCardId;

        public Customer(int customerId, string firstName, string lastName, int phoneNumber, string email, string gender, int points, int loyaltyCardId)
        {
            this.customerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.gender = gender;
            this.points = points;
            this.loyaltyCardId = loyaltyCardId;
        }

        public int CustomerId
        {
            get { return customerId; }
            set
            {
                if (customerId != value)
                {
                    customerId = value;
                    RaisePropertyChanged("CustomerId");
                }
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    RaisePropertyChanged("FirstName");
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    RaisePropertyChanged("LastName");
                }
            }
        }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Points { get => points; set => points = value; }
        public int LoyaltyCardId { get => loyaltyCardId; set => loyaltyCardId = value; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override bool Equals(object? obj)
        {
            return obj is Customer customer &&
                   customerId == customer.customerId &&
                   firstName == customer.firstName &&
                   lastName == customer.lastName &&
                   phoneNumber == customer.phoneNumber &&
                   email == customer.email &&
                   gender == customer.gender &&
                   points == customer.points &&
                   loyaltyCardId == customer.loyaltyCardId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(customerId, firstName, lastName, phoneNumber, email, gender, points, loyaltyCardId);
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
