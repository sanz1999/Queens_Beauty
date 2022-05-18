using Common.Methods.CRUD;
using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels.AppointmentViewModels.AppointmentAddViewModels
{
    public class AppointmentAddCustomerViewModel : BindableBase
    {
        private string firstNameVM;
        private string lastNameVM;
        private string genderVM;
        private string loyaltyCardIdVM;

        private bool isMaleCheckedVM;
        private bool isFemaleCheckedVM;
        private bool isOtherCheckedVM;

        public MyICommand TextChangedCommand { get; set; }

        private CustomerFront selectedItem;
        private CustomerCRUD customerCRUD = new CustomerCRUD();

        public static BindingList<CustomerFront> Customers { get; set; }
        public static BindingList<CustomerFront> CustomersSearch { get; set; }

        public static BindingList<CustomerFront> proxy = new BindingList<CustomerFront>();


        public AppointmentAddCustomerViewModel()
        {
            Customers = new BindingList<CustomerFront>();
            CustomersSearch = new BindingList<CustomerFront>();

            proxy = customerCRUD.LoadFromDataBase();

            foreach (CustomerFront customer in proxy)
                Customers.Add(customer);

            foreach (CustomerFront customer in Customers)
                CustomersSearch.Add(customer);

            TextChangedCommand = new MyICommand(OnTextChanged);
        }

        private void OnTextChanged()
        {
            Filter();
        }

        private void Filter()
        {
            bool canAdd;
            CustomersSearch.Clear();
            foreach (CustomerFront customer in Customers)
            {
                canAdd = CanCustomerPassFilter(customer);
                if (canAdd)
                    CustomersSearch.Add(customer);
            }
        }

        private bool CanCustomerPassFilter(CustomerFront customer)
        {
            if (FirstNameVM != null)
                if (!customer.FirstName.ToLower().Contains(FirstNameVM.ToLower()) && !FirstNameVM.ToLower().Equals(""))
                    return false;
            if (LastNameVM != null)
                if (!customer.LastName.ToLower().Contains(LastNameVM.ToLower()) && !LastNameVM.ToLower().Equals(""))
                    return false;
            if (LoyaltyCardIdVM != null)
                if (!customer.LoyaltyCardId.ToLower().Contains(LoyaltyCardIdVM.ToLower()) && !LoyaltyCardIdVM.ToLower().Equals(""))
                    return false;
            if (IsMaleCheckedVM && !customer.Gender.Equals("Männlich"))
                return false;
            if (IsFemaleCheckedVM && !customer.Gender.Equals("Weiblich"))
                return false;
            if (IsOtherCheckedVM && !customer.Gender.Equals("Anderes"))
                return false;
            return true;
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
                    Filter();
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
                    Filter();
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
                    Filter();
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
                    Filter();
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
                    Filter();
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
                    Filter();
                    OnPropertyChanged("IsOtherCheckedVM");
                }
            }
        }
        public CustomerFront SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }
    }
}
