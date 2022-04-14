﻿using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModels.ServiceViewModels;

namespace ViewModel.ViewModels
{
    public class ServiceViewModel : BindableBase
    {
        private ServiceAddViewModel serviceAddViewModel = new ServiceAddViewModel();
        private ServiceFilterViewModel serviceFilterViewModel = new ServiceFilterViewModel();
        private ServiceInfoViewModel serviceInfoViewModel = new ServiceInfoViewModel();
        private BindableBase currentServiceViewModel;

        private ServiceFront selectedItem;
        private bool canAlter = false;
        private bool canDelete = false;
        public MyICommand<string> NavCommand { get; set; }
        public MyICommand ItemSelectedCommand { get; set; }
        public MyICommand AlterCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand CancelCommand { get; set; }

        public static BindingList<ServiceFront> Services { get; private set; }
        public static BindingList<string> Categories = new BindingList<string>()
        {
            "Sisanje",
            "Feniranje"
            //Dopuniti
        };
        
        public ServiceViewModel()
        {
            Services = new BindingList<ServiceFront>();
            Services.Add(new ServiceFront(0, "Sisanje", "Frizeraj", 30, 5, 10, 2));
            serviceFilterViewModel.Categories = Categories;
            serviceAddViewModel.Categories = Categories;

            NavCommand = new MyICommand<string>(OnNav);
            ItemSelectedCommand = new MyICommand(OnSelect);
            AlterCommand = new MyICommand(OnAlter);
            DeleteCommand = new MyICommand(OnDelete);
            CancelCommand = new MyICommand(OnCancel);

            CurrentServiceViewModel = serviceFilterViewModel;
        }

        private void OnCancel()
        {
            if(CurrentServiceViewModel == serviceAddViewModel)
            {

            }
            else if(CurrentServiceViewModel == serviceFilterViewModel)
            {
                serviceFilterViewModel.ClearInput();
            }
            else if(CurrentServiceViewModel == serviceInfoViewModel)
            {
                serviceInfoViewModel.ClearInput();

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
            Services.Remove(SelectedItem);
            CanAlter = false;
            canDelete = false;
            OnNav("filter");
        }

        private void OnAlter()
        {
            throw new NotImplementedException();
        }

        private void OnSelect()
        {
            if (SelectedItem == null)
                return;

            CanAlter = true;
            CanDelete = true;
            OnNav("info");

            serviceInfoViewModel.NameVM = SelectedItem.Name;
            serviceInfoViewModel.CategoryVM = SelectedItem.Category;
            serviceInfoViewModel.DurationVM = SelectedItem.Duration.ToString();
            serviceInfoViewModel.PriceVM = SelectedItem.Price.ToString();
            serviceInfoViewModel.PointsPriceVM = SelectedItem.PointsPrice.ToString();
            serviceInfoViewModel.PointsValueVM = SelectedItem.PointsValue.ToString();
        }

        private void OnNav(string obj)
        {
            switch (obj)
            {
                case "add":
                    if (CurrentServiceViewModel != serviceAddViewModel)
                    {
                        CurrentServiceViewModel = serviceAddViewModel;
                        CanAlter = false;
                        CanDelete = false;
                        if (SelectedItem == null)
                            break;
                        SelectedItem = null;
                    }
                    else
                    {
                        Services.Add(serviceAddViewModel.GetService());
                        OnNav("filter");

                        CanAlter = false;
                        CanDelete = false;
                    }
                    break;
                case "filter":
                    CurrentServiceViewModel = serviceFilterViewModel;
                    break;
                case "info":
                    CurrentServiceViewModel = serviceInfoViewModel;
                    break;
                case "alter":
                    CurrentServiceViewModel = serviceAddViewModel;
                    break;
            }
        }
        public BindableBase CurrentServiceViewModel
        {
            get { return currentServiceViewModel; }
            set
            {
                SetProperty(ref currentServiceViewModel, value);
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
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
