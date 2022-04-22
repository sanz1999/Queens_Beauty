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
    }
}
