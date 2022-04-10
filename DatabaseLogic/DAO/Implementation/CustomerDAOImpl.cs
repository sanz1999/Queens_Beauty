using Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogic.DAO.Implementation
{
    public class CustomerDAOImpl : ICustomerDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(DBCustomer entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DBCustomer> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DBCustomer> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public DBCustomer FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(DBCustomer entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<DBCustomer> entities)
        {
            throw new NotImplementedException();
        }
    }
}
