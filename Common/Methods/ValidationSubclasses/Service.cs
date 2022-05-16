using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Methods.ValidationSubclasses
{
    public class Service
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
        public bool Duration(string name)
        {
            bool state = true;
            if (name == null) { state = false; }
            else
            {
                name = name.Trim();
                if (name.Equals("")) { state = false; }
            }
            foreach (char c in name)
            {
                if (c < '0' || c > '9')
                {
                    state = false;
                    break;
                }
            }

            return state;
        }
        public int Price(string name)
        {
            int state = 1;
            if (name == null) { state = 0; }
            else
            {
                name = name.Trim();
                if (name.Equals("")) { state =0; }
            }
            foreach (char c in name)
            {
                if ((c < '0' || c > '9')&&( c!=','))
                {
                    if (c == '.') {
                        state = 0;
                    }
                    else {
                        state = -1;
                    }
                    break;
                }
                
            }
            if (name.Count(f => f == ',') > 1)
            {
                state = 4;
            }

            return state;
        }
        public bool PointCost(string name)
        {
            bool state = true;
            if (name == null) { state = false; }
            else
            {
                name = name.Trim();
                if (name.Equals("")) { state = false; }
            }
            foreach (char c in name)
            {
                if (c < '0' || c > '9')
                {
                    state = false;
                    break;
                }
            }
            return state;
        }
        public bool PointReward(string name)
        {
            bool state = true;
            if (name == null) { state = false; }
            else
            {
                name = name.Trim();
                if (name.Equals("")) { state = false; }
            }
            foreach (char c in name)
            {
                if (c < '0' || c > '9')
                {
                    state = false;
                    break;
                }
            }
            return state;
        }

    }
}

