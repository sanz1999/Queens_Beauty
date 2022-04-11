using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DBModel
{
    public class DBWorker
    {
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
        public int id { get; set; }
        public string name { get; set; }

        public DBWorker(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public DBWorker(string name)
        {
            this.name = name;
        }

        public static string GetHeader()
        {
            return string.Format("\n{0, -12} {1, -12}}",
                "W_ID", "W_NAME");
        }

        public override string ToString()
        {

            return string.Format("{0, -12} {1, -12}",
                id, name);
        }
    }
}
