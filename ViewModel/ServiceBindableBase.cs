using Model.FrontendModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ServiceBindableBase : BindableBase
    {
        public static BindingList<ServiceFront> Services { get; set; }
        public static BindingList<ServiceFront> ServicesSearch { get; set; }
        public ServiceBindableBase()
        {

        }
    }
}
