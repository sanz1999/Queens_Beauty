using DatabaseLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCA.UIHandler
{
    public class SIAUIHandler
    {
        private static readonly SIAService siaService = new SIAService();
        private static readonly SIACRUDUIHandler siaCRUDUIHandler = new SIACRUDUIHandler();
        public void MenuHandler()
        {
            string answer;
            int n;

            do
            {
                Console.Clear();
                Console.WriteLine("\nZa povratak na main menu uneti x\nOpcije:");
                Console.WriteLine("1. CRUD TestMenu");
                Console.WriteLine("2. GetAllServicesForID");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        siaCRUDUIHandler.MenuHandler();
                        continue;
                    case "2":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());

                        List<Tuple<int, int>> list = (List<Tuple<int,int>>)siaService.GetAllServicesForId(n);                        

                        foreach (Tuple<int, int> item in list)
                        {
                            Console.WriteLine(item.Item1+" "+item.Item2);
                        }

                        break;
                    case "x":
                        return;
                }
                Console.WriteLine("\n\n\nPress any key to contionue...");
                Console.ReadKey();

            } while (true);
        }
    }
}
