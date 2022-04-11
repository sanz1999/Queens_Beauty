using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Methods
{
    public class Recognition
    {
        public void FilterString(string teext) {
            int provera = -1;
            if (int.TryParse(teext, out provera))
            {
                Console.WriteLine("Unet je broj");
            }
            else if (teext == "")
            {
                Console.WriteLine("Unet je prazan string");
            }
            else {
                Console.WriteLine("Unet je sledeci text za pretragu: " + teext);
            }
        }

    }
}
