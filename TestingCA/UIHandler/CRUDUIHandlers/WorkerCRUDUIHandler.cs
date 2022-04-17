using DatabaseLogic.Services;
using Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCA.UIHandler
{
    public class WorkerCRUDUIHandler
    {
        private static readonly WorkerService workerService = new WorkerService();       

        public void MenuHandler()
        {
            string answer;
            int n;

            do
            {
                Console.Clear();

                Console.WriteLine("\nZa povratak na prethodni menu uneti x\nOpcije:");
                Console.WriteLine("1. Broj radnika");
                Console.WriteLine("2. Izbrisi sve");
                Console.WriteLine("3. Dodaj radnika u tableu");
                Console.WriteLine("4. Proveri dali radnik postoji u tabeli");
                Console.WriteLine("5. Brisi radnika sa datim id-om");
                Console.WriteLine("6. Prikazi sve radnike");
                Console.WriteLine("7. Update na zadati id");
                Console.WriteLine("8. FindAllById");
                Console.WriteLine("9. Nadji i ispisi jednog ranika");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        Console.WriteLine("\nBroj radnika u tabeli : " + workerService.Count());
                        break;
                    case "2":
                        Console.WriteLine("\nBroj izbrisanih radnika: " + workerService.DeleteAll());
                        break;
                    case "3":
                        Console.Write("i = ");
                        n = Int32.Parse(Console.ReadLine());                      
                                                
                        for (int i = 0; i < n; i++)
                        {                         
                            DBWorker u = new DBWorker("TestRadnik");
                            if (workerService.Save(u) == 1)
                                Console.WriteLine("dodavanje uspesno");
                        }                        
                        break;
                    case "4":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());

                        if (workerService.ExistsById(n))
                            Console.WriteLine("Radnik postoji");
                        else
                            Console.WriteLine("Radnik ne postoji");
                        break;
                    case "5":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());

                        if (workerService.DeleteById(n) == 1)
                            Console.WriteLine("Brisanje uspesno");
                        else
                            Console.WriteLine("Brisanje neuspesno");
                        break;
                    case "6":
                        Console.WriteLine();
                        //workerService.FindAll();
                        Console.WriteLine(DBWorker.GetHeader());
                        foreach (DBWorker radnik in workerService.FindAll())
                        {
                            Console.WriteLine(radnik);
                        }
                        break;
                    case "7":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());                        

                        DBWorker updateModel = new DBWorker(n, "UpdateRadnik");
                        
                        if (workerService.Save(updateModel) == 1)
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
                        //workerService.FindAllById(idList);
                        Console.WriteLine(DBWorker.GetHeader());
                        foreach (DBWorker radnik in workerService.FindAllById(idList))
                        {
                            Console.WriteLine(radnik);
                        }

                        break;
                    case "9":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(DBWorker.GetHeader());
                        Console.WriteLine(workerService.FindById(n));
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
