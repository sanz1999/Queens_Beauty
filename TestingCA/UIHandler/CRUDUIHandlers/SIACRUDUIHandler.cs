using DatabaseLogic.Services;
using Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCA.UIHandler
{
    public class SIACRUDUIHandler
    {
        private static readonly SIAService siaService = new SIAService();
        private static readonly AppointmentService appointmentService = new AppointmentService();
        private static readonly ServiceService serviceService = new ServiceService();
        private static readonly WorkerService workerService = new WorkerService();

        public void MenuHandler()
        {
            string answer;
            int n, n2, n3;
            Tuple<int, int> id;

            do
            {
                Console.Clear();

                Console.WriteLine("\nZa povratak na prethodni menu uneti x\nOpcije:");
                Console.WriteLine("1. Broj servisa dodeljenih terminima (clanova tabele)");
                Console.WriteLine("2. Izbrisi sve");
                Console.WriteLine("3. Dodaj <aid,sid> u tableu (Testiranje ovoga moze da se uradi samo jednom pre nego sto sve treba da se obrise iz liste)");
                Console.WriteLine("4. Proveri dali <aid, sid> postoji u tabeli");
                Console.WriteLine("5. Brisi <aid, sid> iz tabele");
                Console.WriteLine("6. Prikazi sve clanove tabele");
                Console.WriteLine("7. Update na zadati <aid, sid> (jedino sto se menja je randik)");
                Console.WriteLine("8. FindAllById");
                Console.WriteLine("9. Nadji i ispisi jednog <aid, sid> clana");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        Console.WriteLine("\nBroj clanova u tabeli : " + siaService.Count());
                        break;
                    case "2":
                        Console.WriteLine("\nBroj izbrisanih clanova: " + siaService.DeleteAll());
                        break;
                    case "3":
                        Console.Write("i = ");
                        n = Int32.Parse(Console.ReadLine());
                        List<DBAppointment> appointments = (List<DBAppointment>)appointmentService.FindAll();
                        List<DBService> services = (List<DBService>)serviceService.FindAll();
                        List<DBWorker> workers = (List<DBWorker>)workerService.FindAll();

                        double value = 0;
                        string method = "c";

                        if (!appointments.Any() && !services.Any())
                        {
                            Console.WriteLine("Za formiranje SIA potreban je makar jedan Appointment i jedan Service");
                        }
                        else
                        {
                            for (int i = 0; i < n; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    method = "p";
                                }
                                else
                                {
                                    method = "c";
                                }

                                if(method == "p")
                                {
                                    value = services.ElementAt(i % services.Count).pointsPrice;
                                }
                                else
                                {
                                    value = services.ElementAt(i % services.Count).price;
                                }

                                id = new Tuple<int,int>(appointments.ElementAt(i % appointments.Count()).appointmentId,
                                                                       services.ElementAt(i % services.Count()).id);
                                DBSIA u = new DBSIA(id, workers.ElementAt(i % workers.Count()).id, value, method);
                                if (siaService.Save(u) == 1)
                                    Console.WriteLine("dodavanje uspesno");
                            }
                        }
                        break;
                    case "4":
                        Console.Write("aid = ");
                        n = Int32.Parse(Console.ReadLine());
                        Console.Write("sid = ");
                        n2 = Int32.Parse(Console.ReadLine());
                        id = new Tuple<int, int>(n, n2);


                        if (siaService.ExistsById(id))
                            Console.WriteLine("Radnik postoji");
                        else
                            Console.WriteLine("Radnik ne postoji");
                        break;
                    case "5":
                        Console.Write("aid = ");
                        n = Int32.Parse(Console.ReadLine());
                        Console.Write("sid = ");
                        n2 = Int32.Parse(Console.ReadLine());
                        id = new Tuple<int, int>(n, n2);

                        if (siaService.DeleteById(id) == 1)
                            Console.WriteLine("Brisanje uspesno");
                        else
                            Console.WriteLine("Brisanje neuspesno");
                        break;
                    case "6":
                        Console.WriteLine();
                        
                        Console.WriteLine(DBSIA.GetHeader());
                        foreach (DBSIA radnik in siaService.FindAll())
                        {
                            Console.WriteLine(radnik);
                        }
                        break;
                    case "7":
                        Console.Write("aid = ");
                        n = Int32.Parse(Console.ReadLine());
                        Console.Write("sid = ");
                        n2 = Int32.Parse(Console.ReadLine());
                        id = new Tuple<int, int>(n, n2);

                        do
                        {
                            Console.Write("wid = ");
                            n3 = Int32.Parse(Console.ReadLine());

                            if (workerService.ExistsById(n3))
                                break;

                            Console.WriteLine("Radnik mora vec da postoji u tabelama");
                        } while (true);


                        DBSIA updateModel = new DBSIA(id, n3);

                        if (siaService.Save(updateModel) == 1)
                            Console.WriteLine("Update uspesan");
                        break;
                    case "8":
                        Console.WriteLine("Unos do 0");
                        List<Tuple<int,int>> idList = new List<Tuple<int,int>>();
                        do
                        {
                            Console.Write("aid = ");
                            n = Int32.Parse(Console.ReadLine());
                            Console.Write("sid = ");
                            n2 = Int32.Parse(Console.ReadLine());
                            id = new Tuple<int, int>(n, n2);
                            idList.Add(id);
                        } while (n != 0);
                        //siaService.FindAllById(idList);
                        Console.WriteLine(DBSIA.GetHeader());
                        foreach (DBSIA sia in siaService.FindAllById(idList))
                        {
                            Console.WriteLine(sia);
                        }

                        break;
                    case "9":
                        Console.Write("aid = ");
                        n = Int32.Parse(Console.ReadLine());
                        Console.Write("sid = ");
                        n2 = Int32.Parse(Console.ReadLine());
                        id = new Tuple<int, int>(n, n2);

                        Console.WriteLine(DBSIA.GetHeader());
                        Console.WriteLine(siaService.FindById(id));
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
