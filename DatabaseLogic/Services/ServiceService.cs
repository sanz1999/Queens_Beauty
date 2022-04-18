using DatabaseLogic.DAO;
using DatabaseLogic.DAO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.DBModel;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;

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
            int ret = -1;

            try
            {
                ret = serviceDAO.Count();
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// Brise sve iz tabele
        /// </summary>
        /// <returns>Vraca broj izbirsanih usluga</returns>
        public int DeleteAll()
        {
            int ret = -1;

            try
            {
                ret = serviceDAO.DeleteAll();
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// Dodaje objekat tipa usluga u tabelu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Vraca 1 u slucaju uspesnog dodavanja</returns>
        public int Save(DBService entity)
        {
            int ret = -1;

            try
            {
                ret = serviceDAO.Save(entity);
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Number);
            }

            return ret;
        }


        /// <summary>
        /// Proverava dali usluga sa datim id-jem postoji u tabeli
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True ako postoji, false ako ne</returns>
        public bool ExistsById(int id)
        {
            bool ret = false;

            try
            {
                ret = serviceDAO.ExistsById(id);
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// Brise prosledjenu uslugu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Vraca 1 ako je brisanje uspesno</returns>
        public int Delete(DBService entity)
        {
            int ret = -1;

            try
            {
                ret = serviceDAO.Delete(entity);
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Number);
            }

            return ret;
        }


        /// <summary>
        /// Brise uslugu sa datim id-om
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Vraca 1 ako je brisanje uspesno</returns>
        public int DeleteById(int id)
        {
            int ret = -1;

            try
            {
                ret = serviceDAO.DeleteById(id);
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Number);
            }

            return ret;
        }


        /// <summary>
        /// Nalazi sve usluge u tabeli
        /// </summary>
        /// <returns>Vraca listu usluga</returns>
        public IEnumerable<DBService> FindAll()
        {
            IEnumerable<DBService> ret = new List<DBService>();

            try
            {
                ret = serviceDAO.FindAll();
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// Nalazi sve usluge sa datim Id-jem.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<DBService> FindAllById(IEnumerable<int> ids)
        {
            IEnumerable<DBService> ret = new List<DBService>();

            try
            {
                ret = serviceDAO.FindAllById(ids);
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// Nalazi i vraca uslugu kao objekat.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DBService FindById(int id)
        {
            DBService ret = null;

            try
            {
                ret = serviceDAO.FindById(id);
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// Koristi se za dodavanje/updatovanje liste prosledjenih usluga.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int SaveAll(IEnumerable<DBService> entities)
        {
            int ret = -1;

            try
            {
                ret = serviceDAO.SaveAll(entities);
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
        public int DeleteByIdLog(int id)
        {
            int ret = -1;

            try
            {
                ret = serviceDAO.DeleteByIdLog(id);
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
        public IEnumerable<DBService> FindAllExisting()
        {
            IEnumerable<DBService> ret = new List<DBService>();

            try
            {
                ret = serviceDAO.FindAllExisting();
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }
    }
}
