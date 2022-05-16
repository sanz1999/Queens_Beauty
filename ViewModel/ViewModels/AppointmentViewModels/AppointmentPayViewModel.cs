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

        public AppointmentPayViewModel()
        {
            SIAList = new BindingList<AppointmentItemFront>();
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
                    double sumPointsD = 0;
                    //Comm
                    if (SIAList.Count != 0)
                        foreach (AppointmentItemFront sia in SIAList)
                        {
                            if (sia.PaymentMethod)
                                sumPointsD += sia.Service.PointsPrice;
                        }
                    sumPoints = sumPointsD.ToString();
                    SumPoints = sumPoints;
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
    }
}
