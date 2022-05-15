﻿using Common.Methods.CRUD;
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
        private AppointmentBindableBase currentAppointmentViewModel;
        private AppointmentCRUD appointmentCRUD = new AppointmentCRUD();

        private AppointmentFront selectedItem;
        private bool canAlter = false;
        private bool canDelete = false;

        public MyICommand<string> NavCommand { get; set; }
        public MyICommand ItemSelectedCommand { get; set; }
        public MyICommand AlterCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand CancelCommand { get; set; }

        public BindingList<AppointmentFront> proxy = new BindingList<AppointmentFront>();

        public AppointmentViewModel()
        {
            //appointmentInfoViewModel.SIAList = new BindingList<AppointmentItemFront>();

            proxy = appointmentCRUD.LoadFromDataBase();

            foreach(AppointmentFront appointment in proxy)
            {
                Appointments.Add(appointment);
            }
            foreach(AppointmentFront appointment in Appointments)
            {
                AppointmentsSearch.Add(appointment);
            }

            NavCommand = new MyICommand<string>(OnNav);
            ItemSelectedCommand = new MyICommand(OnSelect);
            AlterCommand = new MyICommand(OnAlter);
            DeleteCommand = new MyICommand(OnDelete);
            CancelCommand = new MyICommand(OnCancel);

            CurrentAppointmentViewModel = appointmentFilterViewModel;
        }

        private void OnCancel()
        {
            if(CurrentAppointmentViewModel == appointmentAddViewModel)
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

                OnNav("filter");
            }
            else if(CurrentAppointmentViewModel == appointmentFilterViewModel)
            {
                appointmentFilterViewModel.ClearInput();
            }
            else if(CurrentAppointmentViewModel == appointmentInfoViewModel)
            {
                appointmentInfoViewModel.ClearInput();

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
            OnNav("filter");
        }

        private void OnAlter()
        {
            if(CurrentAppointmentViewModel != appointmentAddViewModel)
            {
                appointmentAddViewModel.HeadText = "Alter";

                CurrentAppointmentViewModel = appointmentAddViewModel;
                appointmentInfoViewModel.ClearInput();

                appointmentAddViewModel.SelectedCustomer = SelectedItem.Customer;

                appointmentAddViewModel.AddedSIA.Clear();

                appointmentAddViewModel.AppointmentDateVM = SelectedItem.AppointmentDate.ToString();

                appointmentAddViewModel.StartTimeHour = SelectedItem.StartTime.Substring(0, 2);
                appointmentAddViewModel.StartTimeMinute = SelectedItem.StartTime.Substring(3, 2);

                appointmentAddViewModel.EndTimeHour = SelectedItem.EndTime.Substring(0, 2);
                appointmentAddViewModel.EndTimeMinute = SelectedItem.EndTime.Substring(3, 2);

                appointmentAddViewModel.StateVM = SelectedItem.State;

                foreach(AppointmentItemFront sia in SelectedItem.SIA)
                {
                    appointmentAddViewModel.AddedSIA.Add(sia);
                }
            }
            else
            {   //update treba da se zavrsi
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

                    CanAlter = false;
                    CanDelete = false;

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

            CanAlter = true;
            CanDelete = true;
            OnNav("info");

            appointmentInfoViewModel.CustomerVM = SelectedItem.Customer;
            appointmentInfoViewModel.AppointmentDateVM = SelectedItem.AppointmentDate.ToString();

            appointmentInfoViewModel.StartTimeVM = SelectedItem.StartTime;
            appointmentInfoViewModel.EndTimeVM = SelectedItem.EndTime;

            appointmentInfoViewModel.StateVM = SelectedItem.State;
            appointmentInfoViewModel.SumCenaVM = SelectedItem.SumCena.ToString();

            //appointmentInfoViewModel.SIAList.Clear();
     //       
     //       foreach(ServiceFront service in SelectedItem.ServiceList)
     //       {
     //           appointmentInfoViewModel.ServiceList.Add(service);
     //       }
        }

        private void OnNav(string obj)
        {
            switch (obj)
            {
                case "add":
                    if(CurrentAppointmentViewModel != appointmentAddViewModel)
                    {
                        appointmentAddViewModel.HeadText = "Add";

                        CurrentAppointmentViewModel = appointmentAddViewModel;
                        CanAlter = false;
                        CanDelete = false;
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
                            Appointments.Add(appointmentCRUD.FindLastAdded());
                            AppointmentsSearch.Add(appointmentCRUD.FindLastAdded());
                            OnNav("filter");

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
    }
}
