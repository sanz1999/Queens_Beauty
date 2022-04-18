using DatabaseLogic.DAO;
using DatabaseLogic.DAO.Implementation;
using Model.DBModel;
using Oracle.ManagedDataAccess.Client;
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
            int returnVal = -1;

            try
            {
                returnVal = workerDAO.Count();
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return returnVal;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public int DeleteAll()
        {
            int returnVal = -1;
            
            try { 
            returnVal = workerDAO.DeleteAll();            
            }
            catch(OracleException ex)
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
            int returnVal = -1;

            try
            {
                returnVal = workerDAO.Save(entity);
            }
            catch(OracleException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Number);
            }

            return returnVal;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistsById(int id)
        {
            bool returnVal = false;

            try
            {
                returnVal |= workerDAO.ExistsById(id);
            }
            catch(OracleException ex)
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
        public int Delete(DBWorker entity)
        {
            int returnVal = -1;

            try
            {
                returnVal = workerDAO.Delete(entity);
            }
            catch(OracleException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Number);
            }

            return returnVal;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(int id)
        {
            int returnVal = -1;

            try
            {
                returnVal = workerDAO.DeleteById(id);
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Number);
            }

            return returnVal;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DBWorker> FindAll()
        {
            IEnumerable<DBWorker> retVal = new List<DBWorker>();

            try
            {
                retVal = workerDAO.FindAll();
            } catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return retVal;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<DBWorker> FindAllById(IEnumerable<int> ids)
        {
            IEnumerable<DBWorker> ret = new List<DBWorker>();

            try
            {
                ret = workerDAO.FindAllById(ids);
            }catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DBWorker FindById(int id)
        {
            DBWorker retVal = null;

            try 
            { 
                retVal = workerDAO.FindById(id); 
            }
            catch (OracleException ex) 
            { 
                Console.WriteLine(ex.Message); 
            }

            return retVal;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int SaveAll(IEnumerable<DBWorker> entities)
        {
            int returnVal = -1;
            try
            {
                returnVal = workerDAO.SaveAll(entities);
            } catch(OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return returnVal;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteByIdLog(int id)
        {
            int retVal = -1;

            try 
            { 
                retVal = workerDAO.DeleteByIdLog(id); 
            } catch(OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return retVal;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DBWorker> FindAllExisting()
        {
            IEnumerable<DBWorker> retVal = new List<DBWorker>();

            try { 
                retVal = workerDAO.FindAllExisting();
            } catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return retVal;
        }
    }
}
