using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingCA.UIHandler;

namespace TestingCA
{
    class Program
    {
        private static readonly TestingUIHandler handler = new TestingUIHandler();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            handler.HandleMainMenu();
        }
    }
}
