
using Common.Methods;
using Common.Methods.CRUD;

using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModels.ServiceViewModels;

namespace ViewModel.ViewModels
{
    public class ServiceViewModel : ServiceBindableBase
    {
        private ServiceAddViewModel serviceAddViewModel = new ServiceAddViewModel();
        private ServiceFilterViewModel serviceFilterViewModel = new ServiceFilterViewModel();
        private ServiceInfoViewModel serviceInfoViewModel = new ServiceInfoViewModel();
        private ServiceBindableBase currentServiceViewModel;

        private ServiceCRUD serviceCRUD = new ServiceCRUD();


        private ServiceFront selectedItem;
        private bool canAlter = false;
        private bool canDelete = false;
        public MyICommand<string> NavCommand { get; set; }
        public MyICommand ItemSelectedCommand { get; set; }
        public MyICommand AlterCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand CancelCommand { get; set; }

        public static BindingList<ServiceFront> proxy = new BindingList<ServiceFront>();
        public static BindingList<string> Categories { get; set; }

        private Validation validation = new Validation();

        public ServiceViewModel()
        {
            
            //Services = new BindingList<ServiceFront>();
            //ServicesSearch = new BindingList<ServiceFront>();
            Categories = serviceCRUD.LoadCategories();

            proxy = serviceCRUD.LoadFromDataBase();

            foreach (ServiceFront service in proxy)
                Services.Add(service);

            foreach (ServiceFront service in Services)
                ServicesSearch.Add(service);

            serviceFilterViewModel.Categories = Categories;
            serviceAddViewModel.Categories = Categories;

            NavCommand = new MyICommand<string>(OnNav);
            ItemSelectedCommand = new MyICommand(OnSelect);
            AlterCommand = new MyICommand(OnAlter);
            DeleteCommand = new MyICommand(OnDelete);
            CancelCommand = new MyICommand(OnCancel);

            OnNav("filter");
        }

        private void OnCancel()
        {
            if (CurrentServiceViewModel == serviceAddViewModel)
            {
                serviceAddViewModel.ClearInput();

                
                CanAlter = false;
                CanDelete = false;

                SelectedItem = null;

                OnNav("filter");
                ValidationReset();
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

        private void ValidationReset()
        {
            serviceAddViewModel.IsNameErrorVisible = "Hidden";
            serviceAddViewModel.IsCategoryErrorVisible = "Hidden";
            serviceAddViewModel.IsDurationErrorVisible = "Hidden";
            serviceAddViewModel.IsPriceErrorVisible = "Hidden";
            serviceAddViewModel.IsPointsPriceErrorVisible = "Hidden";
            serviceAddViewModel.IsPointsRewardErrorVisible = "Hidden";
        }

        private void OnDelete()
        {
            if (SelectedItem == null)
                return;

            ServiceFront serviceToRemove = SelectedItem;
            serviceCRUD.DeleteFromDataBase(SelectedItem);
            ServicesSearch.Remove(serviceToRemove);
            Services.Remove(serviceToRemove);
            CanAlter = false;
            canDelete = false;
            OnNav("filter");
        }

        private void OnAlter()
        {

            if (CurrentServiceViewModel != serviceAddViewModel)
            {
                CurrentServiceViewModel = serviceAddViewModel;
                serviceInfoViewModel.ClearInput();

                serviceAddViewModel.NameVM = SelectedItem.Name;
                serviceAddViewModel.CategoryVM = SelectedItem.Category;
                serviceAddViewModel.DurationVM = SelectedItem.Duration.ToString();
                serviceAddViewModel.PriceVM = SelectedItem.Price.ToString();
                serviceAddViewModel.PointsPriceVM = SelectedItem.PointsPrice.ToString();
                serviceAddViewModel.PointsValueVM = SelectedItem.PointsValue.ToString();
            }
            else if(CheckValidation())
            {

                ServiceFront selectedOne = SelectedItem;
                ServiceFront service = serviceAddViewModel.GetService(SelectedItem.Id);
                
                service.Exists = selectedOne.Exists;
                int index = ServicesSearch.IndexOf(SelectedItem);
                int indexReal = Services.IndexOf(SelectedItem);
                ServicesSearch.RemoveAt(index);
                ServicesSearch.Insert(index,service);
                Services.RemoveAt(indexReal);
                Services.Insert(indexReal, service);
                serviceCRUD.UpdateInDataBase(service);


                CanAlter = false;
                CanDelete = false;

                CurrentServiceViewModel = serviceFilterViewModel;
            }
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
                    else if(CheckValidation())
                    {
                        serviceCRUD.AddToDataBase(serviceAddViewModel.GetService());
                        ServicesSearch.Add(serviceCRUD.FindLastAdded());
                        Services.Add(serviceCRUD.FindLastAdded());

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
        private bool CheckValidation()
        {
            if (serviceAddViewModel.NameVM == null ||
                serviceAddViewModel.CategoryVM == null ||
                serviceAddViewModel.DurationVM == null ||
                serviceAddViewModel.PointsPriceVM == null ||
                serviceAddViewModel.PointsValueVM == null ||
                serviceAddViewModel.PriceVM == null)
                return false;
            else if (!serviceAddViewModel.IsNameErrorVisible.Equals("Hidden") ||
                !serviceAddViewModel.IsCategoryErrorVisible.Equals("Hidden") ||
                !serviceAddViewModel.IsDurationErrorVisible.Equals("Hidden") ||
                !serviceAddViewModel.IsPriceErrorVisible.Equals("Hidden") ||
                !serviceAddViewModel.IsPointsPriceErrorVisible.Equals("Hidden") ||
                !serviceAddViewModel.IsPointsRewardErrorVisible.Equals("Hidden"))
                return false;
            return true;
        }
        public ServiceBindableBase CurrentServiceViewModel
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
    }
}
