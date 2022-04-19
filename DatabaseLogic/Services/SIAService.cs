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
    public class SIAService
    {
        private static readonly ISIADAO siaDAO = new SIADAOImpl();

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            int ret = -1;

            try
            {
                ret = siaDAO.Count();
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public int DeleteAll()
        {
            int ret = -1;

            try
            {
                ret = siaDAO.DeleteAll();
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Save(DBSIA entity)
        {
            int ret = -1;

            try
            {
                ret = siaDAO.Save(entity);
            }
            catch (OracleException ex)
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
        public bool ExistsById(Tuple<int,int> id)
        {
            bool ret = false;

            try
            {
                ret = siaDAO.ExistsById(id);
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete(DBSIA entity)
        {
            int ret = -1;

            try
            {
                ret = siaDAO.Delete(entity);
            }
            catch (OracleException ex)
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
        public int DeleteById(Tuple<int,int> id)
        {
            int ret = -1;

            try
            {
                ret = siaDAO.DeleteById(id);
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DBSIA> FindAll()
        {
            IEnumerable<DBSIA> ret = new List<DBSIA>();

            try
            {
                ret = siaDAO.FindAll();
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<DBSIA> FindAllById(IEnumerable<Tuple<int,int>> ids)
        {
            IEnumerable<DBSIA> ret = new List<DBSIA>();

            try
            {
                ret = siaDAO.FindAllById(ids);
            }
            catch (OracleException ex)
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
        public DBSIA FindById(Tuple<int,int> id)
        {
            DBSIA ret = null;

            try
            {
                ret = siaDAO.FindById(id);
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int SaveAll(IEnumerable<DBSIA> entities)
        {
            int ret = -1;

            try
            {
                ret = siaDAO.SaveAll(entities);
            }
            catch (OracleException ex)
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
        public IEnumerable<Tuple<int, int>> GetAllServicesForId(int id)
        {
            IEnumerable<Tuple<int,int>> ret = new List<Tuple<int,int>>();

            try
            {
                ret = siaDAO.GetAllServicesForId(id);
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }

        public int DeleteAllByAppointmentId(int id)
        {
            int ret = -1;

            try
            {
                ret = siaDAO.DeleteAllByAppointmentId(id);
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Number);
            }

            return ret;
        }
    }
}
