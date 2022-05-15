using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DBModel
{
    public class DBSIA
    {
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
        //1. polje je aid, 2. je sid
        public Tuple<int,int> id { get; set; }
        public int workerId { get; set; }
        public double value { get; set; }
        public string method { get; set; }

        public DBSIA(Tuple<int, int> id, int workerId)
        {
            this.id = id;
            this.workerId = workerId;
        }

        public DBSIA()
        {
        }

        public DBSIA(Tuple<int, int> id, int workerId, double value, string method)
        {
            this.id = id;
            this.workerId = workerId;
            this.value = value;
            this.method = method;
        }

        public static string GetHeader()
        {
            return string.Format("\n{0, -12} {1, -12} {2, -12} {3, -12} {4, -12}",
                "A_ID", "S_ID", "W_ID", "PAID", "METHOD");
        }

        public override string ToString()
        {
            return string.Format("{0, -12} {1, -12} {2, -12} {3, -12} {4, -12}",
                id.Item1, id.Item2, workerId, value, method);
        }
    }
}
