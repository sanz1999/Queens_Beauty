using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        private int userId;
        private string firstName;
        private string lastName;
        private int phoneNumber;
        private string email;
        private string gender;
        private int points;
        private int loyaltyCardId;

        public User(int userId, string firstName, string lastName, int phoneNumber, string email, string gender, int points, int loyaltyCardId)
        {
            this.userId = userId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.gender = gender;
            this.points = points;
            this.loyaltyCardId = loyaltyCardId;
        }

        public int UserId { get => userId; set => userId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Points { get => points; set => points = value; }
        public int LoyaltyCardId { get => loyaltyCardId; set => loyaltyCardId = value; }

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   userId == user.userId &&
                   firstName == user.firstName &&
                   lastName == user.lastName &&
                   phoneNumber == user.phoneNumber &&
                   email == user.email &&
                   gender == user.gender &&
                   points == user.points &&
                   loyaltyCardId == user.loyaltyCardId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(userId, firstName, lastName, phoneNumber, email, gender, points, loyaltyCardId);
        }
    }
}
