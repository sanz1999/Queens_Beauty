using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels.CustomerViewModels
{
    public class CustomerInfoViewModel : CustomerBindableBase
    {
        //private int customerIdVM;
        private string firstNameVM;
        private string lastNameVM;
        private string phoneNumberVM;
        private string dateOfBirthVM;
        private string emailVM;
        //private string genderVM;
        //private int pointsVM;
        private string loyaltyCardIdVM;

        private bool isMaleCheckedVM;
        private bool isFemaleCheckedVM;
        private bool isOtherCheckedVM;
        public CustomerInfoViewModel()
        {
        }

        public void ClearInput()
        {
            FirstNameVM = "";
            LastNameVM = "";
            PhoneNumberVM = "";
            DateOfBirthVM = "";
            EmailVM = "";
            LoyaltyCardIdVM = "";
            IsMaleCheckedVM = false;
            IsFemaleCheckedVM = false;
            IsOtherCheckedVM = false;
        }

        public string FirstNameVM
        {
            get { return firstNameVM; }
            set
            {
                if (firstNameVM != value)
                {
                    firstNameVM = value;
                    OnPropertyChanged("FirstNameVM");
                }
            }
        }
        public string LastNameVM
        {
            get { return lastNameVM; }
            set
            {
                if (lastNameVM != value)
                {
                    lastNameVM = value;
                    OnPropertyChanged("LastNameVM");
                }
            }
        }
        public string PhoneNumberVM
        {
            get { return phoneNumberVM; }
            set
            {
                if (phoneNumberVM != value)
                {
                    phoneNumberVM = value;
                    OnPropertyChanged("PhoneNumberVM");
                }
            }
        }
        public string DateOfBirthVM
        {
            get { return dateOfBirthVM; }
            set
            {
                if (dateOfBirthVM != value)
                {
                    dateOfBirthVM = value;
                    OnPropertyChanged("DateOfBirthVM");
                }
            }
        }
        public string EmailVM
        {
            get { return emailVM; }
            set
            {
                if (emailVM != value)
                {
                    emailVM = value;
                    OnPropertyChanged("EmailVM");
                }
            }

        }

        public string LoyaltyCardIdVM
        {
            get { return loyaltyCardIdVM; }
            set
            {
                if (loyaltyCardIdVM != value)
                {
                    loyaltyCardIdVM = value;
                    OnPropertyChanged("LoyaltyCardIdVM");
                }
            }

        }

        public bool IsMaleCheckedVM
        {
            get { return isMaleCheckedVM; }
            set
            {
                if (isMaleCheckedVM != value)
                {
                    isMaleCheckedVM = value;
                    OnPropertyChanged("IsMaleCheckedVM");
                }
            }
        }

        public bool IsFemaleCheckedVM
        {
            get { return isFemaleCheckedVM; }
            set
            {
                if (isFemaleCheckedVM != value)
                {
                    isFemaleCheckedVM = value;
                    OnPropertyChanged("IsFemaleCheckedVM");
                }
            }
        }
        public bool IsOtherCheckedVM
        {
            get { return isOtherCheckedVM; }
            set
            {
                if (isOtherCheckedVM != value)
                {
                    isOtherCheckedVM = value;
                    OnPropertyChanged("IsOtherCheckedVM");
                }
            }
        }

    }
}
