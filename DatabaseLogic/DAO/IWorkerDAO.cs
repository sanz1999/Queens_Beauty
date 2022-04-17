using Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogic.DAO
{
    public interface IWorkerDAO : ICRUDDAO<DBWorker, int>
    {
        int DeleteByIdLog(int id);
    }
}
