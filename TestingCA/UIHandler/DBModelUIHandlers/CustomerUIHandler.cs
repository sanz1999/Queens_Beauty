using DatabaseLogic.Services;
using Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCA.UIHandler
{
    public class CustomerUIHandler
    {
        private static readonly CustomerService customerService = new CustomerService();
        private static readonly CustomerCRUDUIHandler customerCRUDUIHandler = new CustomerCRUDUIHandler(); 
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
                Console.WriteLine("3. Ispis ne izbrisanih clanova");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        customerCRUDUIHandler.MenuHandler();
                        continue;
                    case "2":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());

                        if (customerService.DeleteByIdLog(n) == 1)
                            Console.WriteLine("Brisanje uspesno");
                        else
                            Console.WriteLine("Brisanje neuspesno");

                        break;
                    case "3":
                        Console.WriteLine();
                        //customerService.FindAll();
                        Console.WriteLine(DBCustomer.GetHeader());
                        foreach (DBCustomer musterija in customerService.FindAllExisting())
                        {
                            Console.WriteLine(musterija);
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
