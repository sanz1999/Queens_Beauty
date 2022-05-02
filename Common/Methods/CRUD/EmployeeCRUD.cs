using DatabaseLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model.FrontendModel;
using Model.DBModel;

namespace Common.Methods.CRUD
{
    public class EmployeeCRUD
    {
        private Transform transform = new Transform();
        private WorkerService workerService = new WorkerService();

        public BindingList<EmployeeFront> LoadFromDataBase() {

            BindingList<EmployeeFront> newList = new BindingList<EmployeeFront>();
            List<DBWorker> workerList = (List<DBWorker>)workerService.FindAll();
            foreach (DBWorker worker in workerList) {
                newList.Add(transform.DBToFE.Employee(worker));
            }

            return newList;
        }


    }
}
