using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.FrontendModel
{
    public class CustomerFront : INotifyPropertyChanged
    {
       
            private int customerId;
            private string firstName;
            private string lastName;
            private string phoneNumber;
            private string email;
            private string gender;
            private int points;
            private string loyaltyCardId;


            public CustomerFront() { }


            public CustomerFront(int customerId, string firstName, string lastName, string phoneNumber, string email, string gender, int points, string loyaltyCardId)
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
            public string PhoneNumber 
            {
                get { return phoneNumber; }
                set
                {
                    if (phoneNumber != value)
                    {
                        phoneNumber = value;
                        RaisePropertyChanged("PhoneNumber");
                    }
                }
            }

            public string Email
            {
                get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    RaisePropertyChanged("Email");
                }
            }

            }
            public string Gender{
            get { return gender; }
            set
            {
                if (gender != value) {
                    gender = value;
                    RaisePropertyChanged("Gender");
                }
            }
            }
        
            public int Points { 
            get { return points; }
            set
            {
                if (value != points) {
                    points = value;
                    RaisePropertyChanged("Points");
                }
            }
            }

            public string LoyaltyCardId {
                get { return loyaltyCardId; }
                set {
                    if (loyaltyCardId != value) {
                        loyaltyCardId = value;
                        RaisePropertyChanged("LoyaltyCardId");
                    }
                }
            }
            

            public event PropertyChangedEventHandler? PropertyChanged;

            public override bool Equals(object? obj)
            {
                return obj is CustomerFront customer &&
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
