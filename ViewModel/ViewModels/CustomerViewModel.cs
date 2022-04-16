using Common.Methods;
using Common.Methods.CRUD;
using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModels.CustomerViewModels;

namespace ViewModel.ViewModels
{
    public class CustomerViewModel : BindableBase
    {
        private CustomerAddViewModel customerAddViewModel = new CustomerAddViewModel();
        private CustomerFilterViewModel customerFilterViewModel = new CustomerFilterViewModel();
        private CustomerInfoViewModel customerInfoViewModel = new CustomerInfoViewModel();
        private BindableBase currentCustomerViewModel;
        private CustomerCRUD commonCustomer = new CustomerCRUD();

        private CustomerFront selectedItem;
        private bool canAlter = false;
        private bool canDelete = false;

        private string filterVisibility = "Visible";

        public MyICommand<string> NavCommand { get; set; }
        public MyICommand ItemSelectedCommand { get; set; }
        public MyICommand AlterCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand CancelCommand { get; set; }

        public static BindingList<CustomerFront> Customers { get; set; }
        public static BindingList<CustomerFront> CustomersSearch { get; set; }

        private Validation validation = new Validation();



        public CustomerViewModel()
        {
            Customers = new BindingList<CustomerFront>();
            Customers = commonCustomer.LoadFromDataBase();

            CustomersSearch = new BindingList<CustomerFront>();
            foreach(CustomerFront customer in Customers)
            {
                CustomersSearch.Add(customer);
            }

            NavCommand = new MyICommand<string>(OnNav);
            ItemSelectedCommand = new MyICommand(OnSelect);
            AlterCommand = new MyICommand(OnAlter);
            DeleteCommand = new MyICommand(OnDelete);
            CancelCommand = new MyICommand(OnCancel);

            OnNav("filter");
        }

        private void OnCancel()
        {
            if(CurrentCustomerViewModel == customerAddViewModel)
            {
                customerAddViewModel.ClearInput();
                
                CanAlter = false;
                CanDelete = false;

                SelectedItem = null;

                OnNav("filter");
            }
            else if(CurrentCustomerViewModel == customerFilterViewModel)
            {
                customerFilterViewModel.ClearInput();
            }
            else if(CurrentCustomerViewModel == customerInfoViewModel)
            {
                customerInfoViewModel.ClearInput();
                
                SelectedItem = null;
                CanAlter = false;
                CanDelete = false;

                OnNav("filter");
            }
        }

        private void OnDelete()
        {
            if (SelectedItem == null)
                return;

            commonCustomer.DeleteFromDataBase(SelectedItem);
            CustomersSearch.Remove(SelectedItem);
            CanAlter = false;
            CanDelete = false;
            OnNav("filter");
        }

        private void OnAlter()
        {
            if(CurrentCustomerViewModel != customerAddViewModel)
            {
                //FilterVisibility = "Collapsed";
                CurrentCustomerViewModel = customerAddViewModel;
                customerInfoViewModel.ClearInput();

                customerAddViewModel.FirstNameVM = SelectedItem.FirstName;
                customerAddViewModel.LastNameVM = SelectedItem.LastName;
                customerAddViewModel.PhoneNumberVM = SelectedItem.PhoneNumber;
                customerAddViewModel.EmailVM = SelectedItem.Email;
                customerAddViewModel.LoyaltyCardIdVM = SelectedItem.LoyaltyCardId;

                switch (SelectedItem.Gender)
                {
                    case "Male":
                        customerAddViewModel.IsMaleCheckedVM = true;
                        break;
                    case "Female":
                        customerAddViewModel.IsFemaleCheckedVM = true;
                        break;
                    case "Other":
                        customerAddViewModel.IsOtherCheckedVM = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                CustomerFront selectedOne = SelectedItem;
                CustomerFront newOne = customerAddViewModel.GetCustomer(SelectedItem.CustomerId, SelectedItem.Points);

                newOne.Exists = selectedOne.Exists;
                newOne.DateOfBirth = selectedOne.DateOfBirth;
                int index = CustomersSearch.IndexOf(SelectedItem);
                CustomersSearch.RemoveAt(index);
                CustomersSearch.Insert(index,newOne);

                commonCustomer.UpdateInDataBase(newOne);

                CanAlter = false;
                CanDelete = false;

                OnNav("filter");
            }
        }

        private void OnSelect()
        {
            if (SelectedItem == null)
                return;

            CanAlter = true;
            CanDelete = true;
            OnNav("info");

            customerInfoViewModel.FirstNameVM = SelectedItem.FirstName;
            customerInfoViewModel.LastNameVM = SelectedItem.LastName;
            customerInfoViewModel.PhoneNumberVM = SelectedItem.PhoneNumber;
            customerInfoViewModel.EmailVM = SelectedItem.Email;
            customerInfoViewModel.LoyaltyCardIdVM = SelectedItem.LoyaltyCardId;

            switch (SelectedItem.Gender)
            {
                case "Male":
                    customerInfoViewModel.IsMaleCheckedVM = true;
                    break;
                case "Female":
                    customerInfoViewModel.IsFemaleCheckedVM = true;
                    break;
                case "Other":
                    customerInfoViewModel.IsOtherCheckedVM = true;
                    break;
                default:
                    break;
            }
        }

        private void OnNav(string obj)
        {
            switch (obj)
            {
                case "add":
                    if (CurrentCustomerViewModel != customerAddViewModel)
                    {
                        //FilterVisibility = "Collapsed";
                        CurrentCustomerViewModel = customerAddViewModel;
                        CanAlter = false;
                        CanDelete = false;
                        if (SelectedItem == null)
                            break;
                        SelectedItem = null;
                    }
                    else
                    {
                        commonCustomer.AddToDataBase(customerAddViewModel.GetCustomer());
                        CustomersSearch.Add(commonCustomer.FindLastAdded());
                        OnNav("filter");    

                        CanAlter = false;
                        CanDelete = false;
                    }
                    break;
                case "filter":
                    FilterVisibility = "Visible";
                    CurrentCustomerViewModel = customerFilterViewModel;
                    break;
                case "info":
                    FilterVisibility = "Collapsed";
                    CurrentCustomerViewModel = customerInfoViewModel;
                    break;
                case "alter":
                    FilterVisibility = "Collapsed";
                    CurrentCustomerViewModel = customerAddViewModel;
                    break;
            }
        }
        public BindableBase CurrentCustomerViewModel
        {
            get { return currentCustomerViewModel; }
            set
            {
                SetProperty(ref currentCustomerViewModel, value);
            }
        }

        public bool CanAlter
        {
            get { return canAlter; }
            set
            {
                if (canAlter != value)
                {
                    canAlter = value;
                    OnPropertyChanged("CanAlter");
                }
            }
        }
        public bool CanDelete
        {
            get { return canDelete; }
            set
            {
                if (canDelete != value)
                {
                    canDelete = value;
                    OnPropertyChanged("CanDelete");
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

        public string FilterVisibility
        {
            get { return filterVisibility; }
            set
            {
                if (filterVisibility != value)
                {
                    filterVisibility = value;
                    OnPropertyChanged("FilterVisibility");
                }
            }
        }
    }
}
