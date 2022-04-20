using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model.FrontendModel;
using Model.DBModel;
using DatabaseLogic.Services;

namespace Common.Methods.CRUD
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

        public void AddToDataBase(CustomerFront customer) {        
            DBCustomer dBCustomer = transform.FEToDB.Customer(customer);
            dBCustomer.id = 0;
            dBCustomer.exists = 1;
            customerService.Save(dBCustomer);
        }

        public CustomerFront FindLastAdded() {
            List<DBCustomer> dBCustomers = (List<DBCustomer>)customerService.FindAll();
            return transform.DBToFE.Customer( dBCustomers.Last());
        }

        public void DeleteFromDataBase(CustomerFront customer) {
            customerService.Delete(transform.FEToDB.Customer(customer));
        }
        public void UpdateInDataBase(CustomerFront customer) {
            DBCustomer dBCustomer = transform.FEToDB.Customer(customer);
            customerService.Save(dBCustomer);
        }
    }
}
