using Common.Methods.CRUD;
using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModels.AppointmentViewModels.AppointmentAddViewModels;

namespace ViewModel.ViewModels.AppointmentViewModels
{
    public class AppointmentAddViewModel : AppointmentBindableBase
    {
        AppointmentAddDisplayViewModel appointmentAddDisplayViewModel = new AppointmentAddDisplayViewModel();
        AppointmentAddCustomerViewModel appointmentAddCustomerViewModel = new AppointmentAddCustomerViewModel();
        AppointmentAddServiceViewModel appointmentAddServiceViewModel = new AppointmentAddServiceViewModel();
        BindableBase currentAppointmentAddViewModel;

        //private int appointmentIdVM;
        private CustomerFront customerVM;
        private string appointmentDateVM;
        private string startTimeVM;
        private string endTimeVM;
        private string sumCenaVM;
        private bool stateVM;
        private EmployeeFront employeeVM;

        private CustomerCRUD customerCRUD = new CustomerCRUD();
        private ServiceCRUD serviceCRUD = new ServiceCRUD();

        public BindingList<ServiceFront> ServiceList { get; private set; }

        public BindingList<CustomerFront> Customers { get; private set; }
        public BindingList<CustomerFront> CustomersSearch { get; private set; }

        public BindingList<AppointmentItemFront> AddedSIA { get; private set; }
        

        public BindingList<string> Hours { get; private set; }
        public BindingList<string> Minutes { get; private set; }

        private string filterCustomerVM;
        private CustomerFront selectedCustomer;
        private AppointmentItemFront selectedAddedSIA;

        private string startTimeHour;
        private string startTimeMinute;
        private string endTimeHour;
        private string endTimeMinute;

        private bool canAddService = false;
        private bool canRemoveAddedService = false;

        private string isSelectCustomerVisible = "Visible";
        private string isAddServiceVisible = "Visible";
        private string isFinishVisible = "Collapsed";

        private int idCnt = 0;

        public MyICommand CustomerSelectedCommand { get; set; }
        public MyICommand EmployeeSelectedCommand { get; set; }
        public MyICommand ServiceSelectedCommand { get; set; }
        public MyICommand AddServiceCommand { get; set; }
        public MyICommand AddedServiceSelectedCommand { get; set; }
        public MyICommand RemoveAddedServiceCommand { get; set; }

        private string name;

        public MyICommand<string> NavCommand { get; set; }

        public AppointmentAddViewModel()
        {
            CurrentAppointmentAddViewModel = appointmentAddDisplayViewModel;

            ServiceList = new BindingList<ServiceFront>();

            Customers = new BindingList<CustomerFront>();

            AddedSIA = new BindingList<AppointmentItemFront>();

            CustomersSearch = new BindingList<CustomerFront>();

            Customers = customerCRUD.LoadFromDataBase();
            
            foreach(CustomerFront customer in Customers)
            {
                CustomersSearch.Add(customer);
            }

            Hours = new BindingList<string>() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09",
                "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" };
            Minutes = new BindingList<string>() { "00", "05", "10", "15", "20", "25", "30", "35", "40", "45",
                "50", "55" };

            ServiceSelectedCommand = new MyICommand(OnServiceSelect);
            AddServiceCommand = new MyICommand(OnAddService);
            AddedServiceSelectedCommand = new MyICommand(OnAddedServiceSelect);
            RemoveAddedServiceCommand = new MyICommand(OnRemoveAddedService);
            NavCommand = new MyICommand<string>(OnNav);
        }

        private void OnNav(string obj)
        {
            switch (obj)
            {
                case "customer":
                    if (CurrentAppointmentAddViewModel != appointmentAddCustomerViewModel)
                    {
                        IsAddServiceVisible = "Collapsed";
                        IsSelectCustomerVisible = "Visible";
                        IsFinishVisible = "Collapsed";
                        CurrentAppointmentAddViewModel = appointmentAddCustomerViewModel;
                    }
                    else
                    {
                        SelectedCustomer = appointmentAddCustomerViewModel.SelectedItem;
                        appointmentAddDisplayViewModel.Name = SelectedCustomer.FirstName + " " + SelectedCustomer.LastName;
                        OnNav("display");
                    }
                    break;
                case "services":
                    if (CurrentAppointmentAddViewModel != appointmentAddServiceViewModel)
                    {
                        CurrentAppointmentAddViewModel = appointmentAddServiceViewModel;
                        IsSelectCustomerVisible = "Collapsed";
                        IsAddServiceVisible = "Visible";
                        IsFinishVisible = "Visible";
                    }
                    else
                    {
                        OnAddService();
                    }
                    break;
                case "display":
                    CurrentAppointmentAddViewModel = appointmentAddDisplayViewModel;
                    IsSelectCustomerVisible = "Visible";
                    IsAddServiceVisible = "Visible";
                    IsFinishVisible = "Collapsed";
                    appointmentAddServiceViewModel.SelectedEmployee = null;
                    appointmentAddServiceViewModel.SelectedService = null;
                    break;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public BindableBase CurrentAppointmentAddViewModel
        {
            get { return currentAppointmentAddViewModel; }
            set
            {
                if (currentAppointmentAddViewModel != value)
                {
                    currentAppointmentAddViewModel = value;
                    OnPropertyChanged("CurrentAppointmentAddViewModel");
                }
            }
        }
        private void OnRemoveAddedService()
        {
            AddedSIA.Remove(SelectedAddedSIA);
            CanRemoveAddedService = false;
            SumCenaVM = "0";
        }

        private void OnAddedServiceSelect()
        {
            CanRemoveAddedService = true;
        }

        private void OnAddService()
        {
            AppointmentItemFront SIAToAdd = new AppointmentItemFront(appointmentAddServiceViewModel.SelectedService, appointmentAddServiceViewModel.SelectedEmployee);
            AddedSIA.Add(SIAToAdd);
            SumCenaVM = "0";
            SumCenaVM = "1";
            appointmentAddServiceViewModel.SelectedService = null;
        }

        private void OnServiceSelect()
        {
            CanAddService = true;
        }

        public AppointmentFront GetAppointment()
        {
            string startTime = StartTimeHour + ":" + StartTimeMinute;
            string endTime = EndTimeHour + ":" + EndTimeMinute;
            
            AppointmentFront appointmentToAdd = new AppointmentFront(IdCnt++, SelectedCustomer, DateOnly.Parse(AppointmentDateVM), 
                startTime, endTime, double.Parse(SumCenaVM), StateVM, new BindingList<AppointmentItemFront>());
            foreach (AppointmentItemFront sia in AddedSIA)
                appointmentToAdd.SIA.Add(sia);
            ClearInput();

            return appointmentToAdd;
        }

        public AppointmentFront GetAppointment(int id)
        {
            string startTime = StartTimeHour + ":" + StartTimeMinute;
            string endTime = EndTimeHour + ":" + EndTimeMinute;

            AppointmentFront appointmentToAdd = new AppointmentFront(id, SelectedCustomer, DateOnly.Parse(AppointmentDateVM), 
                startTime, endTime, double.Parse(SumCenaVM), StateVM, new BindingList<AppointmentItemFront>());
            foreach (AppointmentItemFront sia in AddedSIA)
                appointmentToAdd.SIA.Add(sia);
            ClearInput();

            return appointmentToAdd;
        }

        public void ClearInput()
        {
            FilterCustomerVM = "";
            CustomerVM = null;
            AppointmentDateVM = "";
            StartTimeVM = "";
            EndTimeVM = "";
            StateVM = false;
            EmployeeVM = null;

            StartTimeHour = "";
            StartTimeMinute = "";
            EndTimeHour = "";
            EndTimeMinute = "";

            AddedSIA.Clear();

            RaisePropertyChanged("SumCenaVM");
            OnPropertyChanged("SumCenaVM");

            SelectedCustomer = null;

            CanRemoveAddedService = false;
            CanAddService = false;
        }
        public string FilterCustomerVM
        {
            get { return filterCustomerVM; }
            set
            {
                if (filterCustomerVM != value)
                {
                    filterCustomerVM = value;
                    OnPropertyChanged("FilterCustomerVM");
                }
            }
        }
        public CustomerFront CustomerVM
        {
            get { return customerVM; }
            set
            {
                if (customerVM != value)
                {
                    customerVM = value;
                    OnPropertyChanged("CustomerVM");
                }
            }
        }
        public string AppointmentDateVM
        {
            get { return appointmentDateVM; }
            set
            {
                if (appointmentDateVM != value)
                {
                    appointmentDateVM = value;
                    OnPropertyChanged("AppointmentDateVM");
                }
            }
        }
        public string StartTimeVM
        {
            get { return appointmentDateVM; }
            set
            {
                if (startTimeVM != value)
                {
                    startTimeVM = value;
                    OnPropertyChanged("StartTimeVM");
                }
            }
        }
        public string EndTimeVM
        {
            get { return endTimeVM; }
            set
            {
                if (endTimeVM != value)
                {
                    endTimeVM = value;
                    OnPropertyChanged("EndTimeVM");
                }
            }
        }
        public string SumCenaVM
        {
            get { return sumCenaVM; }
            set
            {
                if (sumCenaVM != value)
                {
                    double sumCena = 0;
                    if(AddedSIA.Count!=0)
                        foreach(AppointmentItemFront sia in AddedSIA)
                        {
                            sumCena += sia.Service.Price;
                        }
                    sumCenaVM = sumCena.ToString();
                    SumCenaVM = sumCenaVM;
                    //RaisePropertyChanged("SumCenaVM");
                    OnPropertyChanged("SumCenaVM");
                }
            }
        }
        public bool StateVM
        {
            get { return stateVM; }
            set
            {
                if (stateVM != value)
                {
                    stateVM = value;
                    OnPropertyChanged("StateVM");
                }
            }
        }
        public EmployeeFront EmployeeVM
        {
            get { return employeeVM; }
            set
            {
                if (employeeVM != value)
                {
                    employeeVM = value;
                    OnPropertyChanged("EmployeeVM");
                }
            }
        }
        public CustomerFront SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                if (selectedCustomer != value)
                {
                    selectedCustomer = value;
                    OnPropertyChanged("SelectedCustomer");
                }
            }
        }
        public AppointmentItemFront SelectedAddedSIA
        {
            get { return selectedAddedSIA; }
            set
            {
                if (selectedAddedSIA != value)
                {
                    selectedAddedSIA = value;
                    OnPropertyChanged("SelectedAddedSIA");
                }
            }
        }
        public bool CanAddService
        {
            get { return canAddService; }
            set
            {
                if (canAddService != value)
                {
                    canAddService = value;
                    OnPropertyChanged("CanAddService");
                }
            }
        }
        public bool CanRemoveAddedService
        {
            get { return canRemoveAddedService; }
            set
            {
                if (canRemoveAddedService != value)
                {
                    canRemoveAddedService = value;
                    OnPropertyChanged("CanRemoveAddedService");
                }
            }
        }
        public string StartTimeHour
        {
            get { return startTimeHour; }
            set
            {
                if (startTimeHour != value)
                {
                    startTimeHour = value;
                    OnPropertyChanged("StartTimeHour");
                }
            }
        }
        public string StartTimeMinute
        {
            get { return startTimeMinute; }
            set
            {
                if (startTimeMinute != value)
                {
                    startTimeMinute = value;
                    OnPropertyChanged("StartTimeMinute");
                }
            }
        }
        public string EndTimeHour
        {
            get { return endTimeHour; }
            set
            {
                if (endTimeHour != value)
                {
                    endTimeHour = value;
                    OnPropertyChanged("EndTimeHour");
                }
            }
        }
        public string EndTimeMinute
        {
            get { return endTimeMinute; }
            set
            {
                if (endTimeMinute != value)
                {
                    endTimeMinute = value;
                    OnPropertyChanged("EndTimeMinute");
                }
            }
        }
        public string IsSelectCustomerVisible
        {
            get { return isSelectCustomerVisible; }
            set
            {
                if (isSelectCustomerVisible != value)
                {
                    isSelectCustomerVisible = value;
                    OnPropertyChanged("IsSelectCustomerVisible");
                }
            }
        }
        public string IsAddServiceVisible
        {
            get { return isAddServiceVisible; }
            set
            {
                if (isAddServiceVisible != value)
                {
                    isAddServiceVisible = value;
                    OnPropertyChanged("IsAddServiceVisible");
                }
            }
        }
        public string IsFinishVisible
        {
            get { return isFinishVisible; }
            set
            {
                if (isFinishVisible != value)
                {
                    isFinishVisible = value;
                    OnPropertyChanged("IsFinishVisible");
                }
            }
        }
        public int IdCnt { get => idCnt; set => idCnt = value; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
