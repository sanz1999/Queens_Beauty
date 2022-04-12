using DatabaseLogic.DAO;
using DatabaseLogic.DAO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DatabaseLogic.Services
{
    public class ServiceService
    {
        private static readonly IServiceDAO uslugaDAO = new ServiceDAOImpl();

        /// <summary>
        /// Vraca broj usluga u tabeli
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return uslugaDAO.Count();
        }
        /// <summary>
        /// Brise sve iz tabele
        /// </summary>
        /// <returns>Vraca broj izbirsanih usluga</returns>
        public int DeleteAll()
        {
            return uslugaDAO.DeleteAll();
        }
        /// <summary>
        /// Dodaje objekat tipa usluga u tabelu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Vraca 1 u slucaju uspesnog dodavanja</returns>
        public int Save(Model.DBService entity)
        {
            return uslugaDAO.Save(entity);
        }
        /// <summary>
        /// Proverava dali usluga sa datim id-jem postoji u tabeli
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True ako postoji, false ako ne</returns>
        public bool ExistsById(int id)
        {
            return uslugaDAO.ExistsById(id);
        }
        /// <summary>
        /// Brise prosledjenu uslugu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Vraca 1 ako je brisanje uspesno</returns>
        public int Delete(Model.DBService entity)
        {
            return uslugaDAO.Delete(entity);
        }
        /// <summary>
        /// Brise uslugu sa datim id-om
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Vraca 1 ako je brisanje uspesno</returns>
        public int DeleteById(int id)
        {
            return uslugaDAO.DeleteById(id);
        }
        /// <summary>
        /// Nalazi sve usluge u tabeli
        /// </summary>
        /// <returns>Vraca listu usluga</returns>
        public IEnumerable<Model.DBService> FindAll()
        {
            return uslugaDAO.FindAll();
        }
        /// <summary>
        /// Nalazi sve usluge sa datim Id-jem.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<Model.DBService> FindAllById(IEnumerable<int> ids)
        {
            return uslugaDAO.FindAllById(ids);
        }
        /// <summary>
        /// Nalazi i vraca uslugu kao objekat.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.DBService FindById(int id)
        {
            return uslugaDAO.FindById(id);
        }
        /// <summary>
        /// Koristi se za dodavanje/updatovanje liste prosledjenih usluga.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int SaveAll(IEnumerable<Model.DBService> entities)
        {
            return uslugaDAO.SaveAll(entities);
        }

    }
}
