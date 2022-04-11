using Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogic.DAO.Implementation
{
    public class SIADAOImpl : ISIADAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(DBSIA entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteById(Tuple<int, int> id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(Tuple<int, int> id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DBSIA> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DBSIA> FindAllById(IEnumerable<Tuple<int, int>> ids)
        {
            throw new NotImplementedException();
        }

        public DBSIA FindById(Tuple<int, int> id)
        {
            throw new NotImplementedException();
        }

        public int Save(DBSIA entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<DBSIA> entities)
        {
            throw new NotImplementedException();
        }
    }
}
