using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Methods.ValidationSubclasses
{
    public class Employee
    {
        public bool Name(string name)
        {
            bool state = true;
            if (name == null) { state = false; }
            else
            {
                name = name.Trim();
                if (name.Equals("")) { state = false; }
            }
            return state;
        }
    }
}
