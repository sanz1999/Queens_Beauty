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
        public BindingList<string> LoadCategories() { 
            BindingList<string> newList = new BindingList<string>();
            //now it will be done with on array, but later need to implement including from some file from resources
            List<string> categories = new List<string>();
            categories.Add("Smile SPA");
            categories.Add("Nageldesigne");
            categories.Add("Maderotherapie");
            categories.Add("Gesichtbehandlung");
            categories.Add("Fusspflege");
            categories.Add("Wimpern");
            categories.Add("Augenbraun");
            categories.Add("Wachsen");
            categories.Add("Paraffin");
            categories.Add("QUEEN & KING");

            foreach (string x in categories) {
                newList.Add(x);
            }
            return newList;
        }
        public void AddToDataBase(ServiceFront service) { 
            DBService dBService = transform.FEToDB.Service(service);
            dBService.id = 0;
            serviceService.Save(dBService);
        }
        public ServiceFront FindLastAdded() {
            List<DBService> dBServices = (List<DBService>)serviceService.FindAll();
            return transform.DBToFE.Service(dBServices.Last());
        }
        public void DeleteFromDataBase(ServiceFront service)
        {
            serviceService.Delete(transform.FEToDB.Service(service));
        }

        public void UpdateInDataBase(ServiceFront service) {
            DBService dBService = transform.FEToDB.Service(service);
            serviceService.Save(dBService);
        }
    }
}
