using Model.FrontendModel;
using System.ComponentModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CustomerBindableBase : BindableBase
    {
        public static BindingList<CustomerFront> Customers { get; set; }
        public static BindingList<CustomerFront> CustomersSearch { get; set; }
        public CustomerBindableBase()
        {

        }
    }
}
