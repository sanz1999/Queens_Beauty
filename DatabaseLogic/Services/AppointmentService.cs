using DatabaseLogic.DAO;
using DatabaseLogic.DAO.Implementation;
using Model.DBModel;
using System;
using System.Collections.Generic;
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
            return appointmentDAO.Count();
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public int DeleteAll()
        {
            return appointmentDAO.DeleteAll();
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Save(DBAppointment entity)
        {
            return appointmentDAO.Save(entity);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistsById(int id)
        {
            return appointmentDAO.ExistsById(id);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete(DBAppointment entity)
        {
            return appointmentDAO.Delete(entity);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(int id)
        {
            return appointmentDAO.DeleteById(id);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DBAppointment> FindAll()
        {
            return appointmentDAO.FindAll();
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<DBAppointment> FindAllById(IEnumerable<int> ids)
        {
            return appointmentDAO.FindAllById(ids);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DBAppointment FindById(int id)
        {
            return appointmentDAO.FindById(id);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int SaveAll(IEnumerable<DBAppointment> entities)
        {
            return appointmentDAO.SaveAll(entities);
        }
    }
}
