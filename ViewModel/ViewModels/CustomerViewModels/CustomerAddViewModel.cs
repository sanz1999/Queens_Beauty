﻿using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels.CustomerViewModels
{
    public class CustomerAddViewModel : BindableBase
    {
        //private int customerIdVM;
        private string firstNameVM;
        private string lastNameVM;
        private string phoneNumberVM;
        private string emailVM;
        //private string genderVM;
        //private int pointsVM;
        private string loyaltyCardIdVM;
     
        private bool isMaleCheckedVM;
        private bool isFemaleCheckedVM;
        private bool isOtherCheckedVM;

        private int idCnt = 1;

        public CustomerAddViewModel()
        {
        }
        private string GetGender()
        {
            if (IsMaleCheckedVM) return "Male";
            else if (IsFemaleCheckedVM) return "Female";
            else if (IsOtherCheckedVM) return "Other";
            else return "Unspecified";
        }
        public CustomerFront GetCustomer()
        {
            string gender = GetGender();
            CustomerFront customerToAdd = 
                new CustomerFront(IdCnt++, FirstNameVM, LastNameVM, PhoneNumberVM, EmailVM, gender, 0, LoyaltyCardIdVM);

            ClearInput();

            return customerToAdd;
        }

        public void ClearInput()
        {
            FirstNameVM = "";
            LastNameVM = "";
            PhoneNumberVM = "";
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
                if(isMaleCheckedVM != value)
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

        public int IdCnt { get => idCnt; set => idCnt = value; }
    }
}
