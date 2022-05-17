using Common.Methods;
using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels.ServiceViewModels
{
    public class ServiceAddViewModel : ServiceBindableBase
    {
        //private int idVM;
        private string nameVM;
        private object categoryVM;
        private string durationVM;
        private string priceVM;
        private string pointsPriceVM;
        private string pointsValueVM;

        private string durationErrorText = "Cannot leave duration empty!";
        private string priceErrorText = "Cannot leave price empty!";
        private string pointsPriceErrorText = "Cannot leave points price empty!";
        private string pointsRewardErrorText = "Cannot leave points reward empty!";

        private string headText;

        private string isNameErrorVisible = "Collapsed";
        private string isCategoryErrorVisible = "Collapsed";
        private string isDurationErrorVisible = "Collapsed";
        private string isPriceErrorVisible = "Collapsed";
        private string isPointsPriceErrorVisible = "Collapsed";
        private string isPointsRewardErrorVisible = "Collapsed";

        public BindingList<string> Categories { get; set; }

        public Validation validation = new Validation();

        private int idCnt = 1;
        public ServiceAddViewModel()
        {
        }

        public ServiceFront GetService()
        {

            ServiceFront serviceToAdd = new ServiceFront(IdCnt, NameVM, (string)CategoryVM, int.Parse(DurationVM), double.Parse(priceVM), int.Parse(PointsPriceVM), int.Parse(PointsValueVM));

            ClearInput();
            return serviceToAdd;
        }
        public ServiceFront GetService(int id)
        {

            ServiceFront serviceToAdd = new ServiceFront(id, NameVM, (string)CategoryVM, int.Parse(DurationVM), double.Parse(priceVM), int.Parse(PointsPriceVM), int.Parse(PointsValueVM));

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
                    if (!validation.service.Name(NameVM))
                        IsNameErrorVisible = "Visible";
                    else
                        IsNameErrorVisible = "Collapsed";
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
                    if(categoryVM != null)
                    {
                        IsCategoryErrorVisible = "Collapsed";
                    }
                    else
                    {
                        IsCategoryErrorVisible = "Visible";
                    }
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
                    if (!validation.service.Duration(DurationVM))
                    {
                        if (DurationVM.Equals(""))
                            DurationErrorText = "Cannot leave duration empty";
                        else
                            DurationErrorText = "Cannot have letters in duration!";
                        IsDurationErrorVisible = "Visible";
                    }
                    else
                        IsDurationErrorVisible = "Collapsed";
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
                    if (validation.service.Price(PriceVM)!=1)
                    {
                        if (PriceVM.Equals(""))
                        {
                            PriceErrorText = "Cannot leave price empty!";
                            IsPriceErrorVisible = "Visible";
                        }
                        else if (validation.service.Price(PriceVM) == -1)
                        {
                            PriceErrorText = "Cannot have letters in price!";
                            IsPriceErrorVisible = "Visible";
                        }
                        else if (validation.service.Price(PriceVM) == 0)
                        {
                            PriceErrorText = "Use comma( , ) instead of period( . )";
                            IsPriceErrorVisible = "Visible";
                        }
                        else {
                            PriceErrorText = "Maximum number of commas ( , ) is 1";
                            IsPriceErrorVisible = "Visible";
                        }
                    }
                    else
                        IsPriceErrorVisible = "Collapsed";
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
                    if (!validation.service.PointCost(PointsPriceVM))
                    {
                        if (PointsPriceVM.Equals(""))
                        {
                            PointsPriceErrorText = "Cannot leave points cost empty!";
                            IsPointsPriceErrorVisible = "Visible";
                        }
                        else
                        {
                            PointsPriceErrorText = "Cannot have letters in points cost!";
                            IsPointsPriceErrorVisible = "Visible";
                        }
                    }
                    else
                        IsPointsPriceErrorVisible = "Collapsed";
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
                    if (!validation.service.PointReward(PointsValueVM))
                    {
                        if (PointsValueVM.Equals(""))
                        {
                            PointsRewardErrorText = "Cannot leave points reward empty!";
                            IsPointsRewardErrorVisible = "Visible";
                        }
                        else
                        {
                            PointsRewardErrorText = "Cannot have letters in points reward!";
                            IsPointsRewardErrorVisible = "Visible";
                        }
                    }
                    else
                        IsPointsRewardErrorVisible = "Collapsed";
                    OnPropertyChanged("PointsValueVM");
                }
            }
        }

        public int IdCnt { get => idCnt; set => idCnt = value; }

        public string DurationErrorText
        {
            get { return durationErrorText; }
            set
            {
                if (durationErrorText != value)
                {
                    durationErrorText = value;
                    OnPropertyChanged("DurationErrorText");
                }
            }
        }
        public string PriceErrorText
        {
            get { return priceErrorText; }
            set
            {
                if (priceErrorText != value)
                {
                    priceErrorText = value;
                    OnPropertyChanged("PriceErrorText");
                }
            }
        }
        public string PointsPriceErrorText
        {
            get { return pointsPriceErrorText; }
            set
            {
                if (pointsPriceErrorText != value)
                {
                    pointsPriceErrorText = value;
                    OnPropertyChanged("PointsPriceErrorText");
                }
            }
        }
        public string PointsRewardErrorText
        {
            get { return pointsRewardErrorText; }
            set
            {
                if (pointsRewardErrorText != value)
                {
                    pointsRewardErrorText = value;
                    OnPropertyChanged("PointsRewardErrorText");
                }
            }
        }
        public string IsNameErrorVisible
        {
            get { return isNameErrorVisible; }
            set
            {
                if (isNameErrorVisible != value)
                {
                    isNameErrorVisible = value;
                    OnPropertyChanged("IsNameErrorVisible");
                }
            }
        }
        public string IsCategoryErrorVisible
        {
            get { return isCategoryErrorVisible; }
            set
            {
                if (isCategoryErrorVisible != value)
                {
                    isCategoryErrorVisible = value;
                    OnPropertyChanged("IsCategoryErrorVisible");
                }
            }
        }
        public string IsDurationErrorVisible
        {
            get { return isDurationErrorVisible; }
            set
            {
                if (isDurationErrorVisible != value)
                {
                    isDurationErrorVisible = value;
                    OnPropertyChanged("IsDurationErrorVisible");
                }
            }
        }
        public string IsPriceErrorVisible
        {
            get { return isPriceErrorVisible; }
            set
            {
                if (isPriceErrorVisible != value)
                {
                    isPriceErrorVisible = value;
                    OnPropertyChanged("IsPriceErrorVisible");
                }
            }
        }
        public string IsPointsPriceErrorVisible
        {
            get { return isPointsPriceErrorVisible; }
            set
            {
                if (isPointsPriceErrorVisible != value)
                {
                    isPointsPriceErrorVisible = value;
                    OnPropertyChanged("IsPointsPriceErrorVisible");
                }
            }
        }
        public string IsPointsRewardErrorVisible
        {
            get { return isPointsRewardErrorVisible; }
            set
            {
                if (isPointsRewardErrorVisible != value)
                {
                    isPointsRewardErrorVisible = value;
                    OnPropertyChanged("IsPointsRewardErrorVisible");
                }
            }
        }

        public string HeadText { get => headText; set => headText = value; }
    }
}
