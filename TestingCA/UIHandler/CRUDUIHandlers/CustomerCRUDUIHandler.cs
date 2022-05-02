using DatabaseLogic.Services;
using Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCA.UIHandler
{
    public class CustomerCRUDUIHandler
    {
        private static readonly CustomerService customerService = new CustomerService();
        public void MenuHandler()
        {
            string answer;
            int n, loyal;
            DateTime dt;

            do
            {
                Console.Clear();

                Console.WriteLine("\nZa povratak na prethodni menu uneti x\nOpcije:");
                Console.WriteLine("1. Broj musterija");
                Console.WriteLine("2. Izbrisi sve");
                Console.WriteLine("3. Dodaj musteriju u tableu");
                Console.WriteLine("4. Proveri dali musterija postoji u tabeli");
                Console.WriteLine("5. Brisi musteriju sa datim id-om");
                Console.WriteLine("6. Prikazi sve musterije");
                Console.WriteLine("7. Update na zadati id");
                Console.WriteLine("8. FindAllById");
                Console.WriteLine("9. Nadji i ispisi jednu musteriju");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        Console.WriteLine("\nBroj musterija u tabeli : " + customerService.Count());
                        break;
                    case "2":
                        Console.WriteLine("\nBroj izbrisanih musterija: " + customerService.DeleteAll());
                        break;
                    case "3":
                        Console.Write("i = ");
                        n = Int32.Parse(Console.ReadLine());

                        for (int i = 0; i < n; i++)
                        {
                            dt = DateTime.Now;
                            loyal = customerService.Count();
                            while (customerService.ExistsByLoyaltyNumber(loyal))
                            {
                                loyal++;
                            }
                            DBCustomer u = new DBCustomer("TestIme", "TestPrezime", dt, "TestFon", "TestMail", "T", 123, 0);
                            if (customerService.Save(u) == 1)
                                Console.WriteLine("dodavanje uspesno");
                        }
                        break;
                    case "4":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());

                        if (customerService.ExistsById(n))
                            Console.WriteLine("Data musterija postoji");
                        else
                            Console.WriteLine("Data musterija ne postoji");
                        break;
                    case "5":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());

                        if (customerService.DeleteById(n) == 1)
                            Console.WriteLine("Brisanje uspesno");
                        else
                            Console.WriteLine("Brisanje neuspesno");
                        break;
                    case "6":
                        Console.WriteLine();
                        //customerService.FindAll();
                        Console.WriteLine(DBCustomer.GetHeader());
                        foreach (DBCustomer musterija in customerService.FindAll())
                        {
                            Console.WriteLine(musterija);
                        }
                        break;
                    case "7":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());

                        dt = DateTime.Now;
                        DBCustomer updateModel = new DBCustomer(n, "UpdateIme", "UpdatePrezime", dt, "UpdateFon", "UpdateMAil", "U", 321, customerService.Count()+1);
                        if (customerService.Save(updateModel) == 1)
                            Console.WriteLine("Update uspesan");
                        break;
                    case "8":
                        Console.WriteLine("Unos do 0");
                        List<int> idList = new List<int>();
                        do
                        {
                            Console.Write("id = ");
                            n = Int32.Parse(Console.ReadLine());
                            idList.Add(n);
                        } while (n != 0);
                        //customerService.FindAllById(idList);
                        Console.WriteLine(DBCustomer.GetHeader());
                        foreach (DBCustomer musterija in customerService.FindAllById(idList))
                        {
                            Console.WriteLine(musterija);
                        }

                        break;
                    case "9":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(DBCustomer.GetHeader());
                        Console.WriteLine(customerService.FindById(n));
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
