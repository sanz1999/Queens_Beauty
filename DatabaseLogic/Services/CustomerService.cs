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
    public class CustomerService
    {
        private static readonly ICustomerDAO customerDAO = new CustomerDAOImpl();
        
        /// <summary>
        /// Vraca broj Customer-a u tabeli
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return customerDAO.Count();
        }
        /// <summary>
        /// Brise sve iz tabele
        /// </summary>
        /// <returns>Vraca broj izbirsanih Customer-a</returns>
        public int DeleteAll()
        {
            return customerDAO.DeleteAll();
        }
        /// <summary>
        /// Dodaje objekat tipa Customer u bazu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>1 u slucaju uspesnog dodavanja, 0 ako Save nije uspesan</returns>
        public int Save(DBCustomer entity)
        {
            return customerDAO.Save(entity);
        }
        /// <summary>
        /// Proverava dali Customer sa datim id-jem postoji u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True ako postoji, false ako ne</returns>
        public bool ExistsById(int id)
        {
            return customerDAO.ExistsById(id);
        }
        /// <summary>
        /// Brise prosledjenog Customer-a
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>1 ako je brisanje uspesno, 0 ako nije</returns>
        public int Delete(DBCustomer entity)
        {
            return customerDAO.Delete(entity);
        }
        /// <summary>
        /// Brise Customer-a sa prosledjenim id-om
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 ako je brisanje uspesno, 0 ako nije</returns>
        public int DeleteById(int id)
        {
            return customerDAO.DeleteById(id);
        }
        /// <summary>
        /// Nalazi sve Customer-e u tabeli
        /// </summary>
        /// <returns>Vraca listu Customer-a</returns>
        public IEnumerable<DBCustomer> FindAll()
        {
            return customerDAO.FindAll();
        }
        /// <summary>
        /// Nalazi sve Customer-e sa prosledjenim Id-evima.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>Vraca listu pronadjenih Customer-a</returns>
        public IEnumerable<DBCustomer> FindAllById(IEnumerable<int> ids)
        {
            return customerDAO.FindAllById(ids);
        }
        /// <summary>
        /// Pretrazuje bazu Customer po id-u.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objekat tipa Customer</returns>
        public DBCustomer FindById(int id)
        {
            return customerDAO.FindById(id);
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int SaveAll(IEnumerable<DBCustomer> entities)
        {
            return customerDAO.SaveAll(entities);
        }

        public bool ExistsByLoyaltyNumber(int id)
        {
            return customerDAO.ExistsByLoyaltyNumber((int)id);
        }
        public int DeleteByIdLog(int id)
        {
            return customerDAO.DeleteByIdLog(id);
        }

        public IEnumerable<DBCustomer> FindAllExisting()
        {
            return customerDAO.FindAllExisting();
        }
    }
}
