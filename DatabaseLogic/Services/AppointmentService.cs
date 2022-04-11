using DatabaseLogic.DAO;
using DatabaseLogic.DAO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogic.Services
{
    public class AppointmentService
    {
        private static readonly IAppointmentDAO appointmentDAO = new AppontmentDAOImpl(); 
    }
}
