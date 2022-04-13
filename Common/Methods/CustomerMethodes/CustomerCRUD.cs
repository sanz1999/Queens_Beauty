using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model.FrontendModel;
using Model.DBModel;
using DatabaseLogic.Services;

namespace Common.Methods.CustomerMethodes
{

    public class CustomerCRUD
    {
        private CustomerService customerService = new CustomerService();
        private Transform transform = new Transform();

        public BindingList<CustomerFront> LoadFromDataBase()
        { 
            BindingList<CustomerFront> newList = new BindingList<CustomerFront>();
            List<DBCustomer> dBCustomers = (List<DBCustomer>)customerService.FindAll();
            foreach (DBCustomer dBCustomer in dBCustomers) {
                newList.Add(transform.DBToFE.Customer(dBCustomer));
            }
            return newList;
        }    
    }
}
