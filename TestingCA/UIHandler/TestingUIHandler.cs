using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCA.UIHandler
{
    public class TestingUIHandler
    {
        private static readonly ServiceUIHandler usluga = new ServiceUIHandler();

        public void HandleMainMenu()
        {
            string answer;
            do
            {
                Console.Clear();
                Console.WriteLine("\nZa izlazak uneti x\nOpcije:");
                Console.WriteLine("1. Testiranje usluga");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        usluga.MenuHandler();
                        break;
                    case "x":
                        return;
                }

            } while (true);
        }

    }
}
