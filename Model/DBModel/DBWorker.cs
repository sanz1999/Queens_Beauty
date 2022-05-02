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
        public int exists { get; set; }


        //Koristi se za preuzimanje svih podataka radi ispisa
        public DBWorker(int id, string name, int exists)
        {
            this.id = id;
            this.name = name;
            this.exists = exists;
        }

        //Koristi se za pravljenje Worker-a sa poznatim id-em
        public DBWorker(int id, string name)
        {
            this.id = id;
            this.name = name;           
        }

        //Korisit se za pravljenje Worker-a kojem ce se id dodeliti automatski
        public DBWorker(string name)
        {
            id = 0;
            this.name = name;
        }

        public static string GetHeader()
        {
            return string.Format("\n{0, -12} {1, -12} {2, -12}",
                "W_ID", "W_NAME", "EXISTS");
        }

        public override string ToString()
        {
            return string.Format("{0, -12} {1, -12} {2, -12}",
                id, name, exists);            
        }
    }
}
