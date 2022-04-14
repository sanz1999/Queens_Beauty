using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels.ServiceViewModels
{
    public class ServiceInfoViewModel : BindableBase
    {
        //private int id;
        private string nameVM;
        private string categoryVM;
        private int durationVM;
        private double priceVM;
        private int pointsPriceVM;
        private int pointsValueVM;

        public ServiceInfoViewModel()
        {
        }
        public void ClearInput()
        {
            NameVM = "";
            CategoryVM = "";
            DurationVM = "0";
            PriceVM = "0";
            PointsPriceVM = "0";
            PointsValueVM = "0";
        }

        public string NameVM
        {
            get { return nameVM; }
            set
            {
                if (nameVM != value)
                {
                    nameVM = value;
                    OnPropertyChanged("NameVM");
                }
            }
        }
        public string CategoryVM
        {
            get { return categoryVM; }
            set
            {
                if (categoryVM != value)
                {
                    categoryVM = value;
                    OnPropertyChanged("CategoryVM");
                }
            }
        }
        public string DurationVM
        {
            get { return durationVM.ToString(); }
            set
            {
                if (durationVM.ToString() != value)
                {
                    durationVM = int.Parse(value);
                    OnPropertyChanged("DurationVM");
                }
            }
        }
        
        public string PriceVM
        {
            get { return priceVM.ToString(); }
            set
            {
                if (priceVM.ToString() != value)
                {
                    priceVM = double.Parse(value);
                    OnPropertyChanged("PriceVM");
                }
            }
        }
        public string PointsPriceVM
        {
            get { return pointsPriceVM.ToString(); }
            set
            {
                if (pointsPriceVM.ToString() != value)
                {
                    pointsPriceVM = int.Parse(value);
                    OnPropertyChanged("PointsPriceVM");
                }
            }
        }
        public string PointsValueVM
        {
            get { return pointsValueVM.ToString(); }
            set
            {
                if (pointsValueVM.ToString() != value)
                {
                    pointsValueVM = int.Parse(value);
                    OnPropertyChanged("PointsValueVM");
                }
            }
        }
    }
}
