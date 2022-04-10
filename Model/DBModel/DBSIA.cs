using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DBModel
{
    public class DBSIA
    {
        public int appointmentId { get; set; }
        public int serviceId { get; set; }
        public int workerId { get; set; }

        public DBSIA(int appointmentId, int serviceId, int workerId)
        {
            this.appointmentId = appointmentId;
            this.serviceId = serviceId;
            this.workerId = workerId;
        }

        public static string GetHeader()
        {
            return string.Format("\n{0, -12} {1, -12} {2, -12}",
                "A_ID", "S_ID", "W_ID");
        }

        public override string ToString()
        {
            return string.Format("{0, -12} {1, -12} {2, -12}",
                appointmentId, serviceId, workerId);
        }
    }
}
