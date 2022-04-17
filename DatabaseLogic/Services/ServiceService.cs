using DatabaseLogic.DAO;
using DatabaseLogic.DAO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.DBModel;

namespace DatabaseLogic.Services
{
    public class ServiceService
    {
        private static readonly IServiceDAO serviceDAO = new ServiceDAOImpl();

        /// <summary>
        /// Vraca broj usluga u tabeli
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return serviceDAO.Count();
        }
        /// <summary>
        /// Brise sve iz tabele
        /// </summary>
        /// <returns>Vraca broj izbirsanih usluga</returns>
        public int DeleteAll()
        {
            return serviceDAO.DeleteAll();
        }
        /// <summary>
        /// Dodaje objekat tipa usluga u tabelu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Vraca 1 u slucaju uspesnog dodavanja</returns>
        public int Save(DBService entity)
        {
            return serviceDAO.Save(entity);
        }
        /// <summary>
        /// Proverava dali usluga sa datim id-jem postoji u tabeli
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True ako postoji, false ako ne</returns>
        public bool ExistsById(int id)
        {
            return serviceDAO.ExistsById(id);
        }
        /// <summary>
        /// Brise prosledjenu uslugu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Vraca 1 ako je brisanje uspesno</returns>
        public int Delete(DBService entity)
        {
            return serviceDAO.Delete(entity);
        }
        /// <summary>
        /// Brise uslugu sa datim id-om
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Vraca 1 ako je brisanje uspesno</returns>
        public int DeleteById(int id)
        {
            return serviceDAO.DeleteById(id);
        }
        /// <summary>
        /// Nalazi sve usluge u tabeli
        /// </summary>
        /// <returns>Vraca listu usluga</returns>
        public IEnumerable<DBService> FindAll()
        {
            return serviceDAO.FindAll();
        }
        /// <summary>
        /// Nalazi sve usluge sa datim Id-jem.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<DBService> FindAllById(IEnumerable<int> ids)
        {
            return serviceDAO.FindAllById(ids);
        }
        /// <summary>
        /// Nalazi i vraca uslugu kao objekat.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DBService FindById(int id)
        {
            return serviceDAO.FindById(id);
        }
        /// <summary>
        /// Koristi se za dodavanje/updatovanje liste prosledjenih usluga.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int SaveAll(IEnumerable<DBService> entities)
        {
            return serviceDAO.SaveAll(entities);
        }

        public int DeleteByIdLog(int id)
        {
            return serviceDAO.DeleteByIdLog(id);
        }

        public IEnumerable<DBService> FindAllExisting()
        {
            return serviceDAO.FindAllExisting();
        }
    }
}
