﻿using Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogic.DAO
{
    public interface ICustomerDAO : ICRUDDAO<DBCustomer, int>
    {
        bool ExistsByLoyaltyNumber(int id);
        int DeleteByIdLog(int id);
        IEnumerable<DBCustomer> FindAllExisting();
    }
}
