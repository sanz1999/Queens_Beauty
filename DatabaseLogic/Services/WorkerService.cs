using DatabaseLogic.DAO;
using DatabaseLogic.DAO.Implementation;
using Model.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogic.Services
{
    public class WorkerService
    {
        private static readonly IWorkerDAO workerDAO = new WorkerDAOImpl();

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return workerDAO.Count();
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public int DeleteAll()
        {
            int returnVal = 0;
            
            try { 
            returnVal = workerDAO.DeleteAll();            
            }
            catch(DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return returnVal;
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Save(DBWorker entity)
        {
            return workerDAO.Save(entity);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistsById(int id)
        {
            return workerDAO.ExistsById(id);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete(DBWorker entity)
        {
            return workerDAO.Delete(entity);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(int id)
        {
            return workerDAO.DeleteById(id);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DBWorker> FindAll()
        {
            return workerDAO.FindAll();
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<DBWorker> FindAllById(IEnumerable<int> ids)
        {
            return workerDAO.FindAllById(ids);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DBWorker FindById(int id)
        {
            return workerDAO.FindById(id);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int SaveAll(IEnumerable<DBWorker> entities)
        {
            return workerDAO.SaveAll(entities);
        }

        public int DeleteByIdLog(int id)
        {
            return workerDAO.DeleteByIdLog(id);
        }
    }
}
