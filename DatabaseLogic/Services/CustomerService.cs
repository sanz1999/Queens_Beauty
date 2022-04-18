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
    public class CustomerService
    {
        private static readonly ICustomerDAO customerDAO = new CustomerDAOImpl();
        
        /// <summary>
        /// Vraca broj Customer-a u tabeli
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            int ret = -1;

            try
            {
                ret = customerDAO.Count();
            } catch(DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// Brise sve iz tabele
        /// </summary>
        /// <returns>Vraca broj izbirsanih Customer-a</returns>
        public int DeleteAll()
        {
            int ret = -1;

            try
            {
                ret = customerDAO.DeleteAll();
            } catch(DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// Dodaje objekat tipa Customer u bazu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>1 u slucaju uspesnog dodavanja, 0 ako Save nije uspesan</returns>
        public int Save(DBCustomer entity)
        {
            int ret = -1;

            try
            {
                ret = customerDAO.Save(entity);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// Proverava dali Customer sa datim id-jem postoji u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True ako postoji, false ako ne</returns>
        public bool ExistsById(int id)
        {
            bool ret = false;

            try
            {
                ret = customerDAO.ExistsById(id);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// Brise prosledjenog Customer-a
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>1 ako je brisanje uspesno, 0 ako nije</returns>
        public int Delete(DBCustomer entity)
        {
            int ret = -1;

            try
            {
                ret = customerDAO.Delete(entity);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// Brise Customer-a sa prosledjenim id-om
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 ako je brisanje uspesno, 0 ako nije</returns>
        public int DeleteById(int id)
        {
            int ret = -1;

            try
            {
                ret = customerDAO.DeleteById(id);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// Nalazi sve Customer-e u tabeli
        /// </summary>
        /// <returns>Vraca listu Customer-a</returns>
        public IEnumerable<DBCustomer> FindAll()
        {
            IEnumerable<DBCustomer> ret = new List<DBCustomer>();

            try
            {
                ret = customerDAO.FindAll();
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// Nalazi sve Customer-e sa prosledjenim Id-evima.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>Vraca listu pronadjenih Customer-a</returns>
        public IEnumerable<DBCustomer> FindAllById(IEnumerable<int> ids)
        {
            IEnumerable<DBCustomer> ret = new List<DBCustomer>();

            try
            {
                ret = customerDAO.FindAllById(ids);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// Pretrazuje bazu Customer po id-u.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objekat tipa Customer</returns>
        public DBCustomer FindById(int id)
        {
            DBCustomer ret = null;

            try
            {
                ret = customerDAO.FindById(id);
            }
            catch (DbException ex)
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
        public int SaveAll(IEnumerable<DBCustomer> entities)
        {
            int ret = -1;

            try
            {
                ret = customerDAO.SaveAll(entities);
            }
            catch (DbException ex)
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
        public bool ExistsByLoyaltyNumber(int id)
        {
            bool ret = false;

            try
            {
                ret = customerDAO.ExistsByLoyaltyNumber((int)id);
            }
            catch (DbException ex)
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
                ret = customerDAO.DeleteByIdLog(id);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DBCustomer> FindAllExisting()
        {
            IEnumerable<DBCustomer> ret = new List<DBCustomer>();

            try
            {
                ret = customerDAO.FindAllExisting();
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }
    }
}
