using Common.Methods.CustomerMethodes;
using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels.AppointmentViewModels
{
    public class AppointmentAddViewModel : BindableBase
    {
        //private int appointmentIdVM;
        private CustomerFront customerVM;
        private string appointmentDateVM;
        private string startTimeVM;
        private string endTimeVM;
        private string sumCenaVM;
        private bool stateVM;
        private string employeeNameVM;

        private CustomerCRUD customerCRUD = new CustomerCRUD();
        private ServiceCRUD serviceCRUD = new ServiceCRUD();

        public BindingList<ServiceFront> ServiceList { get; private set; }

        public BindingList<CustomerFront> Customers { get; private set; }
        public BindingList<CustomerFront> CustomersSearch { get; private set; }
        public BindingList<EmployeeFront> Employees { get; private set; }
        public BindingList<EmployeeFront> EmployeesSearch { get; private set; }
        public BindingList<ServiceFront> Services { get; private set; }
        public BindingList<ServiceFront> ServicesSearch { get; private set; }

        public BindingList<ServiceFront> AddedServices { get; private set; }

        public BindingList<string> Hours { get; private set; }
        public BindingList<string> Minutes { get; private set; }

        private string filterCustomerVM;
        private string filterEmployeesVM;
        private string filterServicesVM;
        private CustomerFront selectedCustomer;
        private EmployeeFront selectedEmployee;
        private ServiceFront selectedService;
        private ServiceFront selectedAddedService;

        private string startTimeHour;
        private string startTimeMinute;
        private string endTimeHour;
        private string endTimeMinute;

        private bool canAddService = false;
        private bool canRemoveAddedService = false;

        public MyICommand CustomerSelectedCommand { get; set; }
        public MyICommand EmployeeSelectedCommand { get; set; }
        public MyICommand ServiceSelectedCommand { get; set; }
        public MyICommand AddServiceCommand { get; set; }
        public MyICommand AddedServiceSelectedCommand { get; set; }
        public MyICommand RemoveAddedServiceCommand { get; set; }

        public AppointmentAddViewModel()
        {
            ServiceList = new BindingList<ServiceFront>();

            Customers = new BindingList<CustomerFront>();
            Services = new BindingList<ServiceFront>();

            CustomersSearch = new BindingList<CustomerFront>();
            ServicesSearch = new BindingList<ServiceFront>();

            Customers = customerCRUD.LoadFromDataBase();
            Services = serviceCRUD.LoadFromDataBase();

            foreach(CustomerFront customer in Customers)
            {
                CustomersSearch.Add(customer);
            }
            foreach(ServiceFront service in Services)
            {
                ServicesSearch.Add(service);
            }

            Hours = new BindingList<string>() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09",
                "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" };
            Minutes = new BindingList<string>() { "00", "05", "10", "15", "20", "25", "30", "35", "40", "45",
                "50", "55" };

            CustomerSelectedCommand = new MyICommand(OnCustomerSelect);
            EmployeeSelectedCommand = new MyICommand(OnEmployeeSelect);
            ServiceSelectedCommand = new MyICommand(OnServiceSelect);
            AddServiceCommand = new MyICommand(OnAddedServiceSelect);
            AddedServiceSelectedCommand = new MyICommand(OnAddedServiceSelect);
        }

        private void OnAddedServiceSelect()
        {
            throw new NotImplementedException();
        }

        internal AppointmentFront GetService()
        {
            throw new NotImplementedException();
        }

        private void OnServiceSelect()
        {
            throw new NotImplementedException();
        }

        private void OnEmployeeSelect()
        {
            throw new NotImplementedException();
        }

        private void OnCustomerSelect()
        {
            throw new NotImplementedException();
        }

        public void ClearInput()
        {
            FilterCustomerVM = "";
            FilterEmployeesVM = "";
            FilterServicesVM = "";
            CustomerVM = null;
            AppointmentDateVM = "";
            StartTimeVM = "";
            EndTimeVM = "";
            SumCenaVM = "";
            StateVM = false;
            EmployeeNameVM = "";
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
        public string FilterEmployeesVM
        {
            get { return filterEmployeesVM; }
            set
            {
                if (filterEmployeesVM != value)
                {
                    filterEmployeesVM = value;
                    OnPropertyChanged("FilterEmployeesVM");
                }
            }
        }
        public string FilterServicesVM
        {
            get { return filterServicesVM; }
            set
            {
                if (filterServicesVM != value)
                {
                    filterServicesVM = value;
                    OnPropertyChanged("FilterServicesVM");
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
                    sumCenaVM = value;
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
        public string EmployeeNameVM
        {
            get { return employeeNameVM; }
            set
            {
                if (employeeNameVM != value)
                {
                    employeeNameVM = value;
                    OnPropertyChanged("EmployeeNameVM");
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
        public EmployeeFront SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                if (selectedEmployee != value)
                {
                    selectedEmployee = value;
                    OnPropertyChanged("SelectedEmployee");
                }
            }
        }
        public ServiceFront SelectedService
        {
            get { return selectedService; }
            set
            {
                if (selectedService != value)
                {
                    selectedService = value;
                    OnPropertyChanged("SelectedService");
                }
            }
        }
        public ServiceFront SelectedAddedService
        {
            get { return selectedAddedService; }
            set
            {
                if (selectedAddedService != value)
                {
                    selectedAddedService = value;
                    OnPropertyChanged("SelectedAddedService");
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
    }
}
