using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AppointmentBindableBase : BindableBase
    {
        public static BindingList<AppointmentFront> Appointments { get; set; }
        public static BindingList<AppointmentFront> AppointmentsSearch { get; set; }
        public AppointmentBindableBase()
        {

        }
    }
}
