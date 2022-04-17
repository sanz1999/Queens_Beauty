using DatabaseLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCA.UIHandler
{
    public class WorkerUIHandler
    {
        private static readonly WorkerService workerService = new WorkerService();
        private static readonly WorkerCRUDUIHandler workerCRUDUIHandler = new WorkerCRUDUIHandler();

        public void MenuHandler()
        {
            string answer;
            int n;

            do
            {
                Console.Clear();
                Console.WriteLine("\nZa povratak na main menu uneti x\nOpcije:");
                Console.WriteLine("1. CRUD TestMenu");
                Console.WriteLine("2. Logicko brisanje iz baze");



                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        workerCRUDUIHandler.MenuHandler();
                        continue;
                    case "2":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());

                        if (workerService.DeleteByIdLog(n) == 1)
                            Console.WriteLine("Brisanje uspesno");
                        else
                            Console.WriteLine("Brisanje neuspesno");

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
