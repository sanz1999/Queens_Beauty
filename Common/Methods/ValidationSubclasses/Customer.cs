using DatabaseLogic.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Methods.ValidationSubclasses
{
    
    public class Customer
    {
        private CustomerService customerService = new CustomerService();

        public bool FirstName(string name) {
            bool state = true;
            if (name == null) { state = false; }
            else
            {
                name = name.Trim();
                if (name.Equals("")) { state = false; }
            }
            return state;
        }

        public bool LastName(string name)
        {
            bool state = true;
            if (name == null) { state = false; }
            else
            {
                name = name.Trim();
                if (name.Equals("")) { state = false; }
            }
            return state;
        }

        public bool Email(string email) {
            var foo = new EmailAddressAttribute();
            bool state = true;
            if (email == null) { state = false; }
            else
            {
                email = email.Trim();
                if (email.Equals("")) { state = false; }
                else
                {
                    state = foo.IsValid(email);
                }
            }
            
            return state;
        }
        public bool PhoneNumber(string number) {
            bool state = true;
            foreach (char c in number)
            {
                if (c < '0' || c > '9')
                {
                    state = false;
                    break;
                }
                    
            }

            return state;
        }
        public int LoyalCard(string lcard) {
            int state = 1;
            int loyaltycard = 0;
            foreach (char c in lcard)
            {
                if (c < '0' || c > '9')
                {
                    state = 0;
                    break;
                }

            }
            lcard = lcard.Trim();
            if ((state != 0 ) && (lcard != ""))
            {
                loyaltycard= int.Parse(lcard);
                if (loyaltycard == 0)
                {
                    state = 1;
                }
                else
                {
                    if (customerService.ExistsByLoyaltyNumber(loyaltycard))
                    {
                        state = -1;
                    }
                }
            }
            return state;
        }

    }
}
