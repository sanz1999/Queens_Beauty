﻿using Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogic.DAO
{
    public interface ISIADAO : ICRUDDAO<DBSIA, Tuple<int,int>>
    {
        IEnumerable<Tuple<int,int>> GetAllServicesForId(int id);

        int DeleteAllByAppointmentId(int id);
    }
}
