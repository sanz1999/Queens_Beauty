using DatabaseLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCA.UIHandler
{
    public class ServiceCRUDUIHandler
    {
        private static readonly ServiceService uslugaService = new ServiceService();

        public void MenuHandler()
        {
            string answer;
            int n;
            do
            {
                Console.Clear();

                Console.WriteLine("\nZa povratak na prethodni menu uneti x\nOpcije:");
                Console.WriteLine("1. Broj usluga");
                Console.WriteLine("2. Izbrisi sve");
                Console.WriteLine("3. Dodaj uslugu u tableu");
                Console.WriteLine("4. Proveri dali usluga postoji u tabeli");
                Console.WriteLine("5. Brisi uslugu sa datim id-om");
                Console.WriteLine("6. Prikazi sve usluge");
                Console.WriteLine("7. Update na zadati id");
                Console.WriteLine("8. FindAllById");
                Console.WriteLine("9. Nadji i ispisi jednu uslugu");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        Console.WriteLine("\nBroj usluga u tabeli : " + uslugaService.Count());
                        break;
                    case "2":
                        Console.WriteLine("\nBroj izbrisanih usluga: " + uslugaService.DeleteAll());
                        break;
                    case "3":
                        Console.Write("i = ");
                        n = Int32.Parse(Console.ReadLine());

                        for (int i = 0; i < n; i++)
                        {
                            Model.DBService u = new Model.DBService("Feniranje", "KoŠa", 120, 15.4, 100, 5);
                            if (uslugaService.Save(u) == 1)
                                Console.WriteLine("dodavanje uspesno");
                        }
                        break;
                    case "4":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());

                        if (uslugaService.ExistsById(n))
                            Console.WriteLine("Data usluga postoji");
                        else
                            Console.WriteLine("Data usluga ne postoji");
                        break;
                    case "5":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());

                        if (uslugaService.DeleteById(n) == 1)
                            Console.WriteLine("Brisanje uspesno");
                        else
                            Console.WriteLine("Brisanje neuspesno");
                        break;
                    case "6":
                        Console.WriteLine();
                        //uslugaService.FindAll();
                        Console.WriteLine(Model.DBService.GetHeader());
                        foreach (Model.DBService usluga in uslugaService.FindAll())
                        {
                            Console.WriteLine(usluga);
                        }
                        break;
                    case "7":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());

                        Model.DBService updateModel = new Model.DBService(n, "Brijanje", "Brada", 42, 6.9, -5, 2);
                        if (uslugaService.Save(updateModel) == 1)
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
                        //uslugaService.FindAllById(idList);
                        Console.WriteLine(Model.DBService.GetHeader());
                        foreach (Model.DBService usluga in uslugaService.FindAllById(idList))
                        {
                            Console.WriteLine(usluga);
                        }

                        break;
                    case "9":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(Model.DBService.GetHeader());
                        Console.WriteLine(uslugaService.FindById(n));
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
