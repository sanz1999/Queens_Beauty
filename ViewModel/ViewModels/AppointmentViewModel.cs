using Common.Methods.CRUD;
using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModels.AppointmentViewModels;
using ViewModel.ViewModels.AppointmentViewModels.AppointmentAddViewModels;

namespace ViewModel.ViewModels
{
    public class AppointmentViewModel : AppointmentBindableBase
    {
        private AppointmentAddViewModel appointmentAddViewModel = new AppointmentAddViewModel();
        private AppointmentFilterViewModel appointmentFilterViewModel = new AppointmentFilterViewModel();
        private AppointmentInfoViewModel appointmentInfoViewModel = new AppointmentInfoViewModel();
        private AppointmentPayViewModel appointmentPayViewModel = new AppointmentPayViewModel();
        private AppointmentBindableBase currentAppointmentViewModel;
        private AppointmentCRUD appointmentCRUD = new AppointmentCRUD();

        private AppointmentFront selectedItem;
        private bool canAlter = false;
        private bool canDelete = false;
        private bool canAdd = true;
        private bool canPay = true;
        private bool isPaying = false;

        private string appointmentDateFormatted;

        public MyICommand<string> NavCommand { get; set; }
        public MyICommand ItemSelectedCommand { get; set; }
        public MyICommand AlterCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand CancelCommand { get; set; }
        public MyICommand PayCommand { get; set; }

        public BindingList<AppointmentFront> proxy = new BindingList<AppointmentFront>();


        private string isPayButtonVisible = "Collapsed";


        public AppointmentViewModel()
        {
            //appointmentInfoViewModel.SIAList = new BindingList<AppointmentItemFront>();
        
            proxy = appointmentCRUD.LoadFromDataBase();

            foreach (AppointmentFront appointment in proxy)
            {
                Appointments.Add(appointment);
            }

            int res;
            int resTime;
            AppointmentFront temp;
            //sorting by date and time
            for (int i = 0; i < Appointments.Count; i++)
            {
                for (int j = i; j < Appointments.Count; j++)
                {
                    // res < 0 : appDate earlier than targetDate
                    // res = 0 : appDate same as targetDate
                    // res > 0 : appDate later than targetDate
                    res = Appointments[i].AppointmentDate.CompareTo(Appointments[j].AppointmentDate);
                    if (res > 0)
                    {
                        temp = Appointments[i];
                        Appointments[i] = Appointments[j];
                        Appointments[j] = temp;
                    }
                    else if (res == 0)
                    {
                        resTime = CalculateEarlierByTime(Appointments[i], Appointments[j]);
                        if(resTime == -1)
                        {
                            temp = Appointments[i];
                            Appointments[i] = Appointments[j];
                            Appointments[j] = temp;
                        }
                    }
                }
            }

            foreach (AppointmentFront appointment in Appointments)
            {
                AppointmentsSearch.Add(appointment);
            }

            NavCommand = new MyICommand<string>(OnNav);
            ItemSelectedCommand = new MyICommand(OnSelect);
            AlterCommand = new MyICommand(OnAlter);
            DeleteCommand = new MyICommand(OnDelete);
            CancelCommand = new MyICommand(OnCancel);
            PayCommand = new MyICommand(OnPay);

            CurrentAppointmentViewModel = appointmentFilterViewModel;
        }

        private int CalculateEarlierByTime(AppointmentFront app1, AppointmentFront app2)
        {
            string app1Hours;
            string app1Minutes;
            string app2Hours;
            string app2Minutes;

            try
            {
                app1Hours = app1.StartTime.Substring(0, 2);
                app1Minutes = app1.StartTime.Substring(3, 2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                app1Hours = app1.StartTime.Substring(0, 1);
                app1Minutes = app1.StartTime.Substring(2, 2);
            }
            try
            {
                app2Hours = app2.StartTime.Substring(0, 2);
                app2Minutes = app2.StartTime.Substring(3, 2);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

                app2Hours = app2.StartTime.Substring(0, 1);
                app2Minutes = app2.StartTime.Substring(2, 2);
            }

            int app1HoursNum = int.Parse(app1Hours);
            int app1MinutesNum = int.Parse(app1Minutes);
            int app2HoursNum = int.Parse(app2Hours);
            int app2MinutesNum = int.Parse(app2Minutes);

            // if swap needed
            if (app1HoursNum > app2HoursNum)
                return -1;
            else if (app1HoursNum == app2HoursNum)
            {
                if (app1MinutesNum > app2MinutesNum)
                    return -1;
                else if (app1MinutesNum == app2MinutesNum)
                    return 0;
                else
                    return 1;
            }
            // if swap not needed
            else
                return 1;
        }

        private void OnPay()
        {
            if (CurrentAppointmentViewModel != appointmentPayViewModel)
            {
                CurrentAppointmentViewModel = appointmentPayViewModel;

                appointmentPayViewModel.CustomerVM = SelectedItem.Customer;
                appointmentPayViewModel.SIAList.Clear();
                foreach (AppointmentItemFront sia in SelectedItem.SIA)
                {
                    appointmentPayViewModel.SIAList.Add(sia);
                }

                appointmentPayViewModel.CustomerName = SelectedItem.Customer.FirstName + " " + SelectedItem.Customer.LastName;

                appointmentPayViewModel.SumPrice = "1";
                appointmentPayViewModel.SumPrice = "0";
                appointmentPayViewModel.SumPoints = "1";
                appointmentPayViewModel.SumPoints = "0";
            }
            else
            {
                if (!appointmentPayViewModel.IsPointsErrorVisible.Equals("Visible"))
                {
                    
                    AppointmentFront newOne = new AppointmentFront(
                        SelectedItem.AppointmentId,
                        SelectedItem.Customer,
                        SelectedItem.AppointmentDate,
                        SelectedItem.StartTime,
                        SelectedItem.EndTime,
                        SelectedItem.SumCena,
                        true,
                        SelectedItem.SIA);
                    newOne.SumCena = 0;
                    foreach (var x in newOne.SIA) {
                        if (!x.PaymentMethod)
                        {
                            newOne.SumCena += x.Price;
                        }
                    }
                    int index = Appointments.IndexOf(SelectedItem);
                    int indexSearch = AppointmentsSearch.IndexOf(SelectedItem);
                    appointmentCRUD.UpdateInDataBase(newOne);
                    Appointments.RemoveAt(index);
                    Appointments.Insert(index, newOne);
                    AppointmentsSearch.RemoveAt(indexSearch);
                    AppointmentsSearch.Insert(indexSearch, newOne);

                    appointmentCRUD.RegulatePoints(newOne);

                    appointmentAddViewModel.AppointmentAddCustomerViewModel.SelectedItem = null;
                    appointmentAddViewModel.AppointmentAddCustomerViewModel.FirstNameVM = "";
                    appointmentAddViewModel.AppointmentAddCustomerViewModel.LastNameVM = "";
                    appointmentAddViewModel.AppointmentAddCustomerViewModel.LoyaltyCardIdVM = "";
                    appointmentAddViewModel.AppointmentAddCustomerViewModel.IsMaleCheckedVM = false;
                    appointmentAddViewModel.AppointmentAddCustomerViewModel.IsFemaleCheckedVM = false;
                    appointmentAddViewModel.AppointmentAddCustomerViewModel.IsOtherCheckedVM = false;

                    appointmentAddViewModel.AppointmentAddServiceViewModel.SelectedEmployee = null;
                    appointmentAddViewModel.AppointmentAddServiceViewModel.SelectedService = null;
                    appointmentAddViewModel.AppointmentAddServiceViewModel.FilterEmployeesVM = "";
                    appointmentAddViewModel.AppointmentAddServiceViewModel.FilterServicesVM = "";

                    CanAlter = false;
                    CanDelete = false;

                    CurrentAppointmentViewModel = appointmentFilterViewModel;
                    //DO NOT TOUCH THIS TWO ON CALCELS
                    
                    IsPayButtonVisible = "Collapsed";
                }
            }
        }

        private void OnCancel()
        {
            CanAdd = true;
            if (CurrentAppointmentViewModel == appointmentAddViewModel)
            {
                appointmentAddViewModel.ClearInput();


                CanAlter = false;
                CanDelete = false;

                SelectedItem = null;

                appointmentAddViewModel.IsAddServiceVisible = "Visible";
                appointmentAddViewModel.IsSelectCustomerVisible = "Visible";
                appointmentAddViewModel.CurrentAppointmentAddViewModel = new AppointmentAddDisplayViewModel();

                appointmentAddViewModel.IsAddedServicesErrorVisible = "Collapsed";
                appointmentAddViewModel.IsAddServiceVisible = "Collapsed";
                appointmentAddViewModel.IsDateErrorVisible = "Collapsed";
                appointmentAddViewModel.IsEmptyAddedServicesErrorVisible = "Collapsed";
                appointmentAddViewModel.IsSumCenaErrorVisible = "Collapsed";
                appointmentAddViewModel.IsStartTimeErrorVisible = "Collapsed";

                appointmentAddViewModel.IsSelectCustomerErrorVisible = "Collapsed";
                IsPayButtonVisible = "Collapsed";

                appointmentAddViewModel.AppointmentAddCustomerViewModel.SelectedItem = null;
                appointmentAddViewModel.AppointmentAddCustomerViewModel.FirstNameVM = "";
                appointmentAddViewModel.AppointmentAddCustomerViewModel.LastNameVM = "";
                appointmentAddViewModel.AppointmentAddCustomerViewModel.LoyaltyCardIdVM = "";
                appointmentAddViewModel.AppointmentAddCustomerViewModel.IsMaleCheckedVM = false;
                appointmentAddViewModel.AppointmentAddCustomerViewModel.IsFemaleCheckedVM = false;
                appointmentAddViewModel.AppointmentAddCustomerViewModel.IsOtherCheckedVM = false;

                appointmentAddViewModel.AppointmentAddServiceViewModel.SelectedEmployee = null;
                appointmentAddViewModel.AppointmentAddServiceViewModel.SelectedService = null;
                appointmentAddViewModel.AppointmentAddServiceViewModel.FilterEmployeesVM = "";
                appointmentAddViewModel.AppointmentAddServiceViewModel.FilterServicesVM = "";

                OnNav("filter");
            }
            else if (CurrentAppointmentViewModel == appointmentFilterViewModel)
            {
                appointmentFilterViewModel.ClearInput();
            }
            else if (CurrentAppointmentViewModel == appointmentInfoViewModel)
            {
                appointmentInfoViewModel.ClearInput();
                IsPayButtonVisible = "Collapsed";

                CanAlter = false;
                CanDelete = false;

                SelectedItem = null;

                OnNav("filter");
            }
            else if (CurrentAppointmentViewModel == appointmentPayViewModel)
            {
                IsPayButtonVisible = "Collapsed";

                CanAlter = false;
                CanDelete = false;

                SelectedItem = null;

                OnNav("filter");
            }
        }

        private void OnDelete()
        {
            if (SelectedItem == null)
                return;
            AppointmentFront appointmentToRemove = SelectedItem;
            appointmentCRUD.DeleteFromDataBase(appointmentToRemove);
            Appointments.Remove(appointmentToRemove);
            AppointmentsSearch.Remove(appointmentToRemove);
            CanAlter = false;
            CanDelete = false;
            IsPayButtonVisible = "Collapsed";
            OnNav("filter");
        }

        private void OnAlter()
        {
            if (CurrentAppointmentViewModel != appointmentAddViewModel)
            {
                if (SelectedItem == null)
                    return;

                appointmentAddViewModel.HeadText = "Alter";
                CanAdd = false;
                CanDelete = false;
                IsPayButtonVisible = "Collapsed";

                CurrentAppointmentViewModel = appointmentAddViewModel;
                appointmentInfoViewModel.ClearInput();

                appointmentAddViewModel.SelectedCustomer = SelectedItem.Customer;
                appointmentAddViewModel.AppointmentAddDisplayViewModel.Name = appointmentAddViewModel.SelectedCustomer.FirstName + " " + appointmentAddViewModel.SelectedCustomer.LastName;

                appointmentAddViewModel.AddedSIA.Clear();

                appointmentAddViewModel.AppointmentDateVM = SelectedItem.AppointmentDate.ToString();

                appointmentAddViewModel.StartTimeHour = SelectedItem.StartTime.Substring(0, 2);
                appointmentAddViewModel.StartTimeMinute = SelectedItem.StartTime.Substring(3, 2);


                appointmentAddViewModel.StateVM = SelectedItem.State;
                appointmentAddViewModel.SumCenaVM = SelectedItem.SumCena.ToString();

                foreach (AppointmentItemFront sia in SelectedItem.SIA)
                {
                    appointmentAddViewModel.AddedSIA.Add(sia);
                }

                appointmentAddViewModel.SumCenaVM = "1";
                appointmentAddViewModel.SumCenaVM = "0";
            }
            else
            {   
                if (ValidationCheck())
                {
                    AppointmentFront selectedOne = SelectedItem;
                    
                    AppointmentFront newOne = appointmentAddViewModel.GetAppointment(SelectedItem.AppointmentId);
                    
                    int index = Appointments.IndexOf(SelectedItem);
                    int indexSearch = AppointmentsSearch.IndexOf(SelectedItem);
                    appointmentCRUD.UpdateInDataBase(newOne);
                    Appointments.RemoveAt(index);
                    Appointments.Insert(index, newOne);
                    AppointmentsSearch.RemoveAt(indexSearch);
                    AppointmentsSearch.Insert(indexSearch, newOne);

                    CanAdd = true;
                    CanAlter = false;
                    CanDelete = false;

                    appointmentAddViewModel.AppointmentAddCustomerViewModel.SelectedItem = null;
                    appointmentAddViewModel.AppointmentAddCustomerViewModel.FirstNameVM = "";
                    appointmentAddViewModel.AppointmentAddCustomerViewModel.LastNameVM = "";
                    appointmentAddViewModel.AppointmentAddCustomerViewModel.LoyaltyCardIdVM = "";
                    appointmentAddViewModel.AppointmentAddCustomerViewModel.IsMaleCheckedVM = false;
                    appointmentAddViewModel.AppointmentAddCustomerViewModel.IsFemaleCheckedVM = false;
                    appointmentAddViewModel.AppointmentAddCustomerViewModel.IsOtherCheckedVM = false;

                    appointmentAddViewModel.AppointmentAddServiceViewModel.SelectedEmployee = null;
                    appointmentAddViewModel.AppointmentAddServiceViewModel.SelectedService = null;
                    appointmentAddViewModel.AppointmentAddServiceViewModel.FilterEmployeesVM = "";
                    appointmentAddViewModel.AppointmentAddServiceViewModel.FilterServicesVM = "";

                    CurrentAppointmentViewModel = appointmentFilterViewModel;
                }
            }
        }

        private bool ValidationCheck()
        {
            bool res = true;
            if (appointmentAddViewModel.SelectedCustomer == null)
            {
                appointmentAddViewModel.IsSelectCustomerErrorVisible = "Visible";
                res = false;
            }
            if (appointmentAddViewModel.AddedSIA.Count == 0)
            {
                appointmentAddViewModel.IsEmptyAddedServicesErrorVisible = "Visible";
                res = false;
            }
            if (appointmentAddViewModel.AppointmentDateVM == null)
                res = false;
            if (appointmentAddViewModel.IsDateErrorVisible.Equals("Visible"))
                res = false;
            if (appointmentAddViewModel.SumCenaVM == null)
                res = false;
            if (appointmentAddViewModel.IsSumCenaErrorVisible.Equals("Visible"))
                res = false;
            if (appointmentAddViewModel.StartTimeMinute == null || appointmentAddViewModel.StartTimeHour == null)
            {
                appointmentAddViewModel.IsStartTimeErrorVisible = "Visible";
                res = false;
            }
            if (res)
            {
                appointmentAddViewModel.IsStartTimeErrorVisible = "Collapsed";
                appointmentAddViewModel.IsEmptyAddedServicesErrorVisible = "Collapsed";
            }
            return res;
        }

        private void OnSelect()
        {
            if (SelectedItem == null)
                return;

            IsPayButtonVisible = "Visible";
            if (SelectedItem.State)
                CanPay = false;
            else
                CanPay = true;

            CanAdd = true;

            CanAlter = true;
            CanDelete = true;
            OnNav("info");

            appointmentInfoViewModel.CustomerVM = SelectedItem.Customer;
            appointmentInfoViewModel.AppointmentDateVM = SelectedItem.AppointmentDate.ToString();

            appointmentInfoViewModel.StartTimeVM = SelectedItem.StartTime;
            appointmentInfoViewModel.EndTimeVM = SelectedItem.EndTime;

            appointmentInfoViewModel.StateVM = SelectedItem.State;
            appointmentInfoViewModel.SumCenaVM = SelectedItem.SumCena.ToString();

            appointmentInfoViewModel.SIAList.Clear();

            foreach (AppointmentItemFront sia in SelectedItem.SIA)
            {
                appointmentInfoViewModel.SIAList.Add(sia);
            }

            if (SelectedItem.State == true)
            {
                CanAlter = false;
            }
        }

        private void OnNav(string obj)
        {
            switch (obj)
            {
                case "add":
                    if (CurrentAppointmentViewModel != appointmentAddViewModel)
                    {
                        appointmentAddViewModel.HeadText = "Add";

                        CurrentAppointmentViewModel = appointmentAddViewModel;
                        CanAlter = false;
                        CanDelete = false;
                        appointmentAddViewModel.IsAddServiceVisible = "Visible";
                        IsPayButtonVisible = "Collapsed";
                        if (SelectedItem == null)
                            break;
                        SelectedItem = null;
                    }
                    else
                    {
                        if (ValidationCheck())
                        {
                            AppointmentFront newAppointment = appointmentAddViewModel.GetAppointment();
                            appointmentCRUD.AddToDataBase(newAppointment);
                            newAppointment = appointmentCRUD.FindLastAdded();
                            Appointments.Add(newAppointment);
                            AppointmentsSearch.Add(newAppointment);
                            appointmentAddViewModel.AppointmentAddDisplayViewModel.Name = "";
                            appointmentAddViewModel.ValidationReset();
                            OnNav("filter");

                            appointmentAddViewModel.AppointmentAddCustomerViewModel.SelectedItem = null;
                            appointmentAddViewModel.AppointmentAddCustomerViewModel.FirstNameVM = "";
                            appointmentAddViewModel.AppointmentAddCustomerViewModel.LastNameVM = "";
                            appointmentAddViewModel.AppointmentAddCustomerViewModel.LoyaltyCardIdVM = "";
                            appointmentAddViewModel.AppointmentAddCustomerViewModel.IsMaleCheckedVM = false;
                            appointmentAddViewModel.AppointmentAddCustomerViewModel.IsFemaleCheckedVM = false;
                            appointmentAddViewModel.AppointmentAddCustomerViewModel.IsOtherCheckedVM = false;

                            appointmentAddViewModel.AppointmentAddServiceViewModel.SelectedEmployee = null;
                            appointmentAddViewModel.AppointmentAddServiceViewModel.SelectedService = null;
                            appointmentAddViewModel.AppointmentAddServiceViewModel.FilterEmployeesVM = "";
                            appointmentAddViewModel.AppointmentAddServiceViewModel.FilterServicesVM = "";

                            CanAlter = false;
                            CanDelete = false;
                        }
                    }
                    break;
                case "filter":
                    CurrentAppointmentViewModel = appointmentFilterViewModel;
                    break;
                case "info":
                    CurrentAppointmentViewModel = appointmentInfoViewModel;
                    break;
                case "alter":
                    CurrentAppointmentViewModel = appointmentAddViewModel;
                    break;
            }
        }

        public AppointmentBindableBase CurrentAppointmentViewModel
        {
            get { return currentAppointmentViewModel; }
            set
            {
                SetProperty(ref currentAppointmentViewModel, value);
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

        public bool CanPay
        {
            get { return canPay; }
            set
            {
                if (canPay != value)
                {
                    canPay = value;
                    OnPropertyChanged("CanPay");
                }
            }
        }
        public string IsPayButtonVisible
        {
            get { return isPayButtonVisible; }
            set
            {
                if (isPayButtonVisible != value)
                {
                    isPayButtonVisible = value;
                    OnPropertyChanged("IsPayButtonVisible");
                }
            }
        }

        public bool CanAdd
        {
            get { return canAdd; }
            set
            {
                if (canAdd != value)
                {
                    canAdd = value;
                    OnPropertyChanged("CanAdd");
                }
            }
        }


        public AppointmentFront SelectedItem
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

        public bool IsPaying
        {
            get { return isPaying; }
            set
            {
                if (isPaying != value)
                {
                    isPaying = value;
                    OnPropertyChanged("IsPaying");
                }
            }
        }
        public string AppointmentDateFormatted
        {
            get { return appointmentDateFormatted; }
            set
            {
                if (appointmentDateFormatted != value)
                {
                    appointmentDateFormatted = value;
                    OnPropertyChanged("AppointmentDateFormatted");
                }
            }
        }
}
}
