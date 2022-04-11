using Common.Methods;
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
        private static readonly Recognition funkcije = new Recognition();
        public void HandleMainMenu()
        {
            string answer;
            do
            {
                Console.Clear();
                Console.WriteLine("\nZa izlazak uneti x\nOpcije:");
                Console.WriteLine("1. Testiranje usluga");
                Console.WriteLine("2. Testiraj filtriranje");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        usluga.MenuHandler();
                        break;
                    case "2":
                        TestIt();
                        break;
                    case "x":
                        return;
                }

            } while (true);
        }

        public void TestIt() {
            Console.WriteLine("Unesite string za filtraciju");
            string answer = Console.ReadLine();
            funkcije.FilterString(answer);
            Console.ReadKey();
        }

    }
}
