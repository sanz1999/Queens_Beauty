using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels.AppointmentViewModels.AppointmentAddViewModels
{
    public class AppointmentAddDisplayViewModel : BindableBase
    {
        private string name;

        private string isSelectCustomerErrorVisible = "Hidden";
        public AppointmentAddDisplayViewModel()
        {
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string IsSelectCustomerErrorVisible
        {
            get { return isSelectCustomerErrorVisible; }
            set
            {
                if (isSelectCustomerErrorVisible != value)
                {
                    isSelectCustomerErrorVisible = value;
                    OnPropertyChanged("IsSelectCustomerErrorVisible");
                }
            }
        }
    }
}
