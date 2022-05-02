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
    public class AppointmentAddServiceViewModel : BindableBase
    {
        private string filterEmployeesVM;
        private string filterServicesVM;
        private EmployeeFront selectedEmployee;
        private ServiceFront selectedService;
        private ServiceCRUD serviceCRUD = new ServiceCRUD();
        private  EmployeeCRUD employeeCRUD = new EmployeeCRUD();
        public BindingList<EmployeeFront> Employees { get; private set; }
        public BindingList<EmployeeFront> EmployeesSearch { get; private set; }
        public BindingList<ServiceFront> Services { get; private set; }
        public BindingList<ServiceFront> ServicesSearch { get; private set; }

        public MyICommand EmployeeTextChangedCommand { get; set; }
        public MyICommand ServiceTextChangedCommand { get; set; }

        public AppointmentAddServiceViewModel()
        {
            Services = serviceCRUD.LoadFromDataBase();
            Employees = employeeCRUD.LoadFromDataBase();

            ServicesSearch = new BindingList<ServiceFront>();
            EmployeesSearch = new BindingList<EmployeeFront>();

            foreach (ServiceFront service in Services)
            {
                ServicesSearch.Add(service);
            }
            foreach (EmployeeFront employee in Employees)
            {
                EmployeesSearch.Add(employee);
            }

            EmployeeTextChangedCommand = new MyICommand(OnEmployeeTextChanged);
            ServiceTextChangedCommand = new MyICommand(OnServiceTextChanged);
        }

        private void OnServiceTextChanged()
        {
            FilterServices();
        }

        private void FilterServices()
        {
            bool canAdd;
            ServicesSearch.Clear();
            foreach (ServiceFront service in Services)
            {
                canAdd = CanServicePassFilter(service);
                if (canAdd)
                    ServicesSearch.Add(service);
            }
        }

        private bool CanServicePassFilter(ServiceFront service)
        {
            if (FilterServicesVM != null)
                if (!service.Name.ToLower().Contains(FilterServicesVM.ToLower()) && !FilterServicesVM.ToLower().Equals(""))
                    return false;
            return true;
        }

        private void OnEmployeeTextChanged()
        {
            FilterEmployees();
        }

        private void FilterEmployees()
        {
            bool canAdd;
            EmployeesSearch.Clear();
            foreach (EmployeeFront employee in Employees)
            {
                canAdd = CanEmployeePassFilter(employee);
                if (canAdd)
                    EmployeesSearch.Add(employee);
            }
        }

        private bool CanEmployeePassFilter(EmployeeFront employee)
        {
            if (FilterEmployeesVM != null)
                if (!employee.Name.ToLower().Contains(FilterEmployeesVM.ToLower()) && !FilterEmployeesVM.ToLower().Equals(""))
                    return false;
            return true;
        }

        public string FilterEmployeesVM
        {
            get { return filterEmployeesVM; }
            set
            {
                if (filterEmployeesVM != value)
                {
                    filterEmployeesVM = value;
                    FilterEmployees();
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
                    FilterServices();
                    OnPropertyChanged("FilterServicesVM");
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
    }
}
