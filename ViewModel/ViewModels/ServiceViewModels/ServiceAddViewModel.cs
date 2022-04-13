using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels.ServiceViewModels
{
    public class ServiceAddViewModel : BindableBase
    {
        //private int idVM;
        private string nameVM;
        private object categoryVM;
        private string durationVM;
        private string priceVM;
        private string pointsPriceVM;
        private string pointsValueVM;

        public BindingList<string> Categories { get; set; }

        private int idCnt = 1;
        public ServiceAddViewModel()
        {
        }

        public ServiceFront GetService()
        {
            ServiceFront serviceToAdd = new ServiceFront(IdCnt, NameVM, CategoryVM.ToString(), int.Parse(DurationVM), int.Parse(priceVM), int.Parse(PointsPriceVM), int.Parse(PointsValueVM));
            ClearInput();
            return serviceToAdd;
        }
        public ServiceFront GetService(int id)
        {
            ServiceFront serviceToAdd = new ServiceFront(id, NameVM, CategoryVM.ToString(), int.Parse(DurationVM), int.Parse(priceVM), int.Parse(PointsPriceVM), int.Parse(PointsValueVM));
            ClearInput();
            return serviceToAdd;
        }

        public void ClearInput()
        {
            NameVM = "";
            CategoryVM = null;
            DurationVM = "";
            PriceVM = "";
            PointsPriceVM = "";
            PointsValueVM = "";
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
        public object CategoryVM
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
            get { return durationVM; }
            set
            {
                if (durationVM != value)
                {
                    durationVM = value;
                    OnPropertyChanged("DurationVM");
                }
            }
        }
        public string PriceVM
        {
            get { return priceVM; }
            set
            {
                if (priceVM != value)
                {
                    priceVM = value;
                    OnPropertyChanged("PriceVM");
                }
            }
        }
        public string PointsPriceVM
        {
            get { return pointsPriceVM; }
            set
            {
                if (pointsPriceVM != value)
                {
                    pointsPriceVM = value;
                    OnPropertyChanged("PointsPriceVM");
                }
            }
        }
        public string PointsValueVM
        {
            get { return pointsValueVM; }
            set
            {
                if (pointsValueVM != value)
                {
                    pointsValueVM = value;
                    OnPropertyChanged("PointsValueVM");
                }
            }
        }

        public int IdCnt { get => idCnt; set => idCnt = value; }
    }
}
