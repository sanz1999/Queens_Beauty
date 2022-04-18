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
    public class AppointmentService
    {
        private static readonly IAppointmentDAO appointmentDAO = new AppontmentDAOImpl();

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            int ret = -1;

            try
            {
                ret = appointmentDAO.Count();
            }catch(OracleException ex)
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
                ret = appointmentDAO.DeleteAll();
            } catch(OracleException ex)
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
        public int Save(DBAppointment entity)
        {
            int ret = -1;

            try
            {
                ret = appointmentDAO.Save(entity);
            } catch(OracleException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Number);
            }

            return ret;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistsById(int id)
        {
            bool ret = false;

            try
            {
                ret = appointmentDAO.ExistsById(id);
            } catch (OracleException ex)
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
        public int Delete(DBAppointment entity)
        {
            int ret = -1;

            try
            {
                ret = appointmentDAO.Delete(entity);
            } catch(OracleException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Number);
            }

            return ret;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(int id)
        {
            int ret = -1;

            try
            {
                ret = appointmentDAO.DeleteById(id);
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Number);
            }

            return ret;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DBAppointment> FindAll()
        {
            IEnumerable<DBAppointment> ret = new List<DBAppointment>();

            try
            {
                ret = appointmentDAO.FindAll();
            } catch (OracleException ex)
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
        public IEnumerable<DBAppointment> FindAllById(IEnumerable<int> ids)
        {
            IEnumerable<DBAppointment> ret = new List<DBAppointment>();

            try
            {
                ret = appointmentDAO.FindAllById(ids);
            } catch (OracleException ex)
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
        public DBAppointment FindById(int id)
        {
            DBAppointment ret = null;

            try
            {
                ret = appointmentDAO.FindById(id);
            } catch(OracleException ex)
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
        public int SaveAll(IEnumerable<DBAppointment> entities)
        {
            int ret = -1;

            try
            {
                ret = appointmentDAO.SaveAll(entities);
            }
            catch(OracleException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Number);
            }

            return ret;
        }
    }
}
