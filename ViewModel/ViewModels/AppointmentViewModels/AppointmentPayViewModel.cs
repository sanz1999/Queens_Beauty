using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels.AppointmentViewModels
{
    public class AppointmentPayViewModel : AppointmentBindableBase
    {
        private CustomerFront customerVM;
        private bool stateVM;
        private string sumCenaVM;

        public BindingList<AppointmentItemFront> SIAList { get; set; }

        private AppointmentItemFront selectedSIA;

        private string sumPrice;
        private string sumPoints;

        private string customerName;

        private string isPointsErrorVisible = "Hidden";

        public MyICommand ItemSelectedCommand { get; set; }

        public AppointmentPayViewModel()
        {
            SIAList = new BindingList<AppointmentItemFront>();

            ItemSelectedCommand = new MyICommand(OnSelect);
        }

        private void OnSelect()
        {
            SumPoints = "1";
            SumPoints = "0";
            SumPrice = "1";
            SumPrice = "0";
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
        public AppointmentItemFront SelectedSIA
        {
            get { return selectedSIA; }
            set
            {
                if (selectedSIA != value)
                {
                    selectedSIA = value;
                    OnPropertyChanged("SelectedSIA");
                }
            }
        }
        public string SumPrice
        {
            get { return sumPrice; }
            set
            {
                if (sumPrice != value)
                {
                    double sumPriceD = 0;
                    if(SIAList.Count != 0)
                    foreach(AppointmentItemFront sia in SIAList)
                    {
                        if (!sia.PaymentMethod)
                            sumPriceD += sia.Service.Price;
                    }
                    sumPrice = sumPriceD.ToString();
                    SumPrice = sumPrice;
                    OnPropertyChanged("SumPrice");
                }
            }
        }
        public string SumPoints
        {
            get { return sumPoints; }
            set
            {
                if (sumPoints != value)
                {
                    int sumPointsD = 0;
                    if (SIAList.Count != 0)
                        foreach (AppointmentItemFront sia in SIAList)
                        {
                            if (sia.PaymentMethod)
                                sumPointsD += sia.Service.PointsPrice;
                        }
                    sumPoints = sumPointsD.ToString();
                    SumPoints = sumPoints;
                    if(sumPointsD > CustomerVM.Points)
                    {
                        IsPointsErrorVisible = "Visible";
                    }
                    else
                    {
                        IsPointsErrorVisible = "Hidden";
                    }
                    OnPropertyChanged("SumPoints");
                }
            }
        }
        public string CustomerName
        {
            get { return customerName; }
            set
            {
                if (customerName != value)
                {
                    customerName = value;
                    OnPropertyChanged("CustomerName");
                }
            }
        }
        public string IsPointsErrorVisible
        {
            get { return isPointsErrorVisible; }
            set
            {
                if(isPointsErrorVisible != value)
                {
                    isPointsErrorVisible = value;
                    OnPropertyChanged("IsPointsErrorVisible");
                }
            }
        }
    }
}
