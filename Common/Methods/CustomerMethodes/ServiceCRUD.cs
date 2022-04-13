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
    public class ServiceCRUD
    {
        private Transform transform = new Transform();
        private ServiceService serviceService = new ServiceService();

        public BindingList<ServiceFront> LoadFromDataBase() {
            BindingList<ServiceFront> newList = new BindingList<ServiceFront>();
            List<DBService> dBServices = (List<DBService>)serviceService.FindAll();
            foreach (DBService dBService in dBServices) {
                newList.Add(transform.DBToFE.Service(dBService));
            }
            return newList;
        }
    }
}
