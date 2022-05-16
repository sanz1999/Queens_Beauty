using Common.Methods;
using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels.CustomerViewModels
{
    public class CustomerAddViewModel : CustomerBindableBase
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


        private string phoneNumberErrorText;
        private string emailErrorText;
        private string loyaltyCardIdErrorText;

        private string isFirstNameErrorVisible = "Collapsed";
        private string isLastNameErrorVisible = "Collapsed";
        private string isPhoneNumberErrorVisible = "Collapsed";
        private string isBirthdayErrorVisible = "Collapsed";
        private string isEmailErrorVisible = "Collapsed";
        private string isLoyaltyCardIdErrorVisible = "Collapsed";

        private string headText;

        private int idCnt = 1;

        private Validation validation = new Validation();

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
            if (LoyaltyCardIdVM == "")
                LoyaltyCardIdVM = null;
            CustomerFront customerToAdd = 
                new CustomerFront(IdCnt++, FirstNameVM, LastNameVM, PhoneNumberVM, (DateOfBirthVM == null || DateOfBirthVM == "") ? DateTime.MaxValue.ToString() : DateOfBirthVM, (EmailVM == null || EmailVM == "") ? "" : EmailVM, gender, 0, (LoyaltyCardIdVM == null || LoyaltyCardIdVM == "") ? "0" : LoyaltyCardIdVM, 1);

            ClearInput();

            return customerToAdd;
        }

        public CustomerFront GetCustomer(int id, int points)
        {
            string gender = GetGender();
            if (LoyaltyCardIdVM == "")
                LoyaltyCardIdVM = null;

            CustomerFront customerToAdd =
                new CustomerFront(id, FirstNameVM, LastNameVM, PhoneNumberVM, (DateOfBirthVM==null || DateOfBirthVM == "") ? DateTime.MaxValue.ToString():DateOfBirthVM, (EmailVM == null || EmailVM == "") ? "" : EmailVM, gender, points, (LoyaltyCardIdVM == null || LoyaltyCardIdVM == "") ? "0" : LoyaltyCardIdVM, 1); ;

            ClearInput();

            return customerToAdd;
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
                    if (!validation.customer.FirstName(FirstNameVM))
                        IsFirstNameErrorVisible = "Visible";
                    else
                        IsFirstNameErrorVisible = "Collapsed";
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
                    if (!validation.customer.LastName(LastNameVM))
                        IsLastNameErrorVisible = "Visible";
                    else
                        IsLastNameErrorVisible = "Collapsed";
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
                    if (!validation.customer.PhoneNumber(PhoneNumberVM))
                    {
                        if (PhoneNumberVM.Equals(""))
                            PhoneNumberErrorText = "Cannot leave phone number empty!";
                        else
                            PhoneNumberErrorText = "Phone number cannot have letters!";
                        IsPhoneNumberErrorVisible = "Visible";
                    }
                    else
                        IsPhoneNumberErrorVisible = "Collapsed";
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
                    if (!validation.customer.Birthday(DateOfBirthVM))
                        IsBirthdayErrorVisible = "Visible";
                    else
                        IsBirthdayErrorVisible = "Collapsed";
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
                    if (!validation.customer.Email(EmailVM))
                    {
                        if (EmailVM.Equals(""))
                            EmailErrorText = "Cannot leave email empty!";
                        else
                            EmailErrorText = "Email not in correct format!";
                        IsEmailErrorVisible = "Visible";
                    }
                    else
                        IsEmailErrorVisible = "Collapsed";
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
                    if (validation.customer.LoyalCard(LoyaltyCardIdVM) == 0)
                    {
                        LoyaltyCardIdErrorText = "Cannot have letters in loyalty card ID!";
                        IsLoyaltyCardIdErrorVisible = "Visible";
                    }
                    else if ((validation.customer.LoyalCard(LoyaltyCardIdVM) == -1) &&(HeadText!= "Alter") )
                    {
                        LoyaltyCardIdErrorText = "ID already assigned to a customer!";
                        IsLoyaltyCardIdErrorVisible = "Visible";
                    }
                    else
                        IsLoyaltyCardIdErrorVisible = "Collapsed";
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
        public string IsFirstNameErrorVisible
        {
            get { return isFirstNameErrorVisible; }
            set
            {
                if (isFirstNameErrorVisible != value)
                {
                    isFirstNameErrorVisible = value;
                    OnPropertyChanged("IsFirstNameErrorVisible");
                }
            }
        }
        public string IsLastNameErrorVisible
        {
            get { return isLastNameErrorVisible; }
            set
            {
                if(isLastNameErrorVisible != value)
                {
                    isLastNameErrorVisible = value;
                    OnPropertyChanged("IsLastNameErrorVisible");
                }
            }
        }
        public string IsPhoneNumberErrorVisible
        {
            get { return isPhoneNumberErrorVisible; }
            set
            {
                if (isPhoneNumberErrorVisible != value)
                {
                    isPhoneNumberErrorVisible = value;
                    OnPropertyChanged("IsPhoneNumberErrorVisible");
                }
            }
        }
        public string IsBirthdayErrorVisible
        {
            get { return isBirthdayErrorVisible; }
            set
            {
                if (isBirthdayErrorVisible != value)
                {
                    isBirthdayErrorVisible = value;
                    OnPropertyChanged("IsBirthdayErrorVisible");
                }
            }
        }
        public int IdCnt { get => idCnt; set => idCnt = value; }
        public string PhoneNumberErrorText
        {
            get { return phoneNumberErrorText; }
            set
            {
                if (phoneNumberErrorText != value)
                {
                    phoneNumberErrorText = value;
                    OnPropertyChanged("PhoneNumberErrorText");
                }
            }
        }
        public string EmailErrorText
        {
            get { return emailErrorText; }
            set
            {
                if (emailErrorText != value)
                {
                    emailErrorText = value;
                    OnPropertyChanged("EmailErrorText");
                }
            }
        }
        public string IsEmailErrorVisible
        {
            get { return isEmailErrorVisible; }
            set
            {
                if (isEmailErrorVisible != value)
                {
                    isEmailErrorVisible = value;
                    OnPropertyChanged("IsEmailErrorVisible");
                }
            }
        }
        public string LoyaltyCardIdErrorText
        {
            get { return loyaltyCardIdErrorText; }
            set
            {
                if (loyaltyCardIdErrorText != value)
                {
                    loyaltyCardIdErrorText = value;
                    OnPropertyChanged("LoyaltyCardIdErrorText");
                }
            }
        }
        public string IsLoyaltyCardIdErrorVisible
        {
            get { return isLoyaltyCardIdErrorVisible; }
            set
            {
                if (isLoyaltyCardIdErrorVisible != value)
                {
                    isLoyaltyCardIdErrorVisible = value;
                    OnPropertyChanged("IsLoyaltyCardIdErrorVisible");
                }
            }
        }

        public string HeadText { get => headText; set => headText = value; }
    }
}
