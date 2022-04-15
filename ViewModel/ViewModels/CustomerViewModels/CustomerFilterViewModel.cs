using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels.CustomerViewModels
{
    public class CustomerFilterViewModel : BindableBase
    {
        private string firstNameVM;
        private string lastNameVM;
        private string genderVM;
        private string loyaltyCardIdVM;

        private bool isMaleCheckedVM;
        private bool isFemaleCheckedVM;
        private bool isOtherCheckedVM;

        public CustomerFilterViewModel()
        { 
        }

        public void ClearInput()
        {
            FirstNameVM = "";
            LastNameVM = "";
            GenderVM = "";
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
        public string GenderVM
        {
            get { return genderVM; }
            set
            {
                if (genderVM != value)
                {
                    genderVM = value;
                    OnPropertyChanged("GenderVM");
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
