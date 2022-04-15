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
            if (name == "") { state = false; ; }
            return state;
        }
    }
}
