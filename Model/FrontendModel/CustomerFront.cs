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
            private string dateOfBirth;
            private string email;
            private string gender;
            private int points;
            private string loyaltyCardId;
            private int exists;


            public CustomerFront() { }


            public CustomerFront(int customerId, string firstName, string lastName, string phoneNumber, string dateOfBirth, string email, string gender, int points, string loyaltyCardId, int exists)
            {
                this.customerId = customerId;
                this.firstName = firstName;
                this.lastName = lastName;
                this.phoneNumber = phoneNumber;
                this.dateOfBirth = dateOfBirth;
                this.email = email;
                this.gender = gender;
                this.points = points;
                this.loyaltyCardId = loyaltyCardId;
                this.exists = exists;
            }

            public int CustomerId
            {
                get    { return customerId; }
                set
                {
                    if (customerId != value)
                    {
                        customerId = value;
                        RaisePropertyChanged("CustomerId");
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
            public string DateOfBirth
        {
                get { return dateOfBirth; }
                set
                {
                    if (dateOfBirth != value)
                    {
                        dateOfBirth = value;
                        RaisePropertyChanged("DateOfBirth");
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
            return obj is CustomerFront front &&
                   customerId == front.customerId &&
                   firstName == front.firstName &&
                   lastName == front.lastName &&
                   phoneNumber == front.phoneNumber &&
                   dateOfBirth == front.dateOfBirth &&
                   email == front.email &&
                   gender == front.gender &&
                   points == front.points &&
                   loyaltyCardId == front.loyaltyCardId &&
                   exists == front.exists;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(customerId);
            hash.Add(firstName);
            hash.Add(lastName);
            hash.Add(phoneNumber);
            hash.Add(dateOfBirth);
            hash.Add(email);
            hash.Add(gender);
            hash.Add(points);
            hash.Add(loyaltyCardId);
            hash.Add(exists);
            return hash.ToHashCode();
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
