using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModels.AppointmentViewModels;

namespace ViewModel.ViewModels
{
    public class AppointmentViewModel : BindableBase
    {
        private AppointmentAddViewModel appointmentAddViewModel = new AppointmentAddViewModel();
        private AppointmentFilterViewModel appointmentFilterViewModel = new AppointmentFilterViewModel();
        private AppointmentInfoViewModel appointmentInfoViewModel = new AppointmentInfoViewModel();
        private BindableBase currentAppointmentViewModel;

        private ServiceFront selectedItem;
        private bool canAlter = false;
        private bool canDelete = false;

        public MyICommand<string> NavCommand { get; set; }
        public MyICommand ItemSelectedCommand { get; set; }
        public MyICommand AlterCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand CancelCommand { get; set; }

        public static BindingList<AppointmentFront> Appointments { get; private set; }
        public AppointmentViewModel()
        {
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

                OnNav("filter");
            }
            else if(CurrentAppointmentViewModel == appointmentFilterViewModel)
            {
                appointmentFilterViewModel.ClearInput();
            }
            else if(CurrentAppointmentViewModel == appointmentInfoViewModel)
            {

            }
        }

        private void OnDelete()
        {
            throw new NotImplementedException();
        }

        private void OnAlter()
        {
            throw new NotImplementedException();
        }

        private void OnSelect()
        {
            throw new NotImplementedException();
        }

        private void OnNav(string obj)
        {
            switch (obj)
            {
                case "add":
                    if(CurrentAppointmentViewModel != appointmentAddViewModel)
                    {
                        CurrentAppointmentViewModel = appointmentAddViewModel;
                        CanAlter = false;
                        CanDelete = false;
                        if (SelectedItem == null)
                            break;
                        SelectedItem = null;
                    }
                    else
                    {
                        Appointments.Add(appointmentAddViewModel.GetService());
                        OnNav("filter");

                        CanAlter = false;
                        CanDelete = false;
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

        public BindableBase CurrentAppointmentViewModel
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

        public ServiceFront SelectedItem
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
