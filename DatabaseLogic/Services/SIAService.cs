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
    public class SIAService
    {
        private static readonly ISIADAO siaDAO = new SIADAOImpl();

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return siaDAO.Count();
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public int DeleteAll()
        {
            return siaDAO.DeleteAll();
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Save(DBSIA entity)
        {
            return siaDAO.Save(entity);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistsById(Tuple<int,int> id)
        {
            return siaDAO.ExistsById(id);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete(DBSIA entity)
        {
            return siaDAO.Delete(entity);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(Tuple<int,int> id)
        {
            return siaDAO.DeleteById(id);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DBSIA> FindAll()
        {
            return siaDAO.FindAll();
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<DBSIA> FindAllById(IEnumerable<Tuple<int,int>> ids)
        {
            return siaDAO.FindAllById(ids);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DBSIA FindById(Tuple<int,int> id)
        {
            return siaDAO.FindById(id);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int SaveAll(IEnumerable<DBSIA> entities)
        {
            return siaDAO.SaveAll(entities);
        }
    }
}
