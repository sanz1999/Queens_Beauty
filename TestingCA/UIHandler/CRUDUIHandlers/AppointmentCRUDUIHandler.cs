using DatabaseLogic.Services;
using Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCA.UIHandler
{
    public class AppointmentCRUDUIHandler
    {
        private static readonly AppointmentService appointmentService = new AppointmentService();
        private static readonly CustomerService customerService = new CustomerService();
        public void MenuHandler()
        {
            string answer;
            int n;
            DateTime datum;


            do
            {
                Console.Clear();

                Console.WriteLine("\nZa povratak na prethodni menu uneti x\nOpcije:");
                Console.WriteLine("1. Broj termina");
                Console.WriteLine("2. Izbrisi sve");
                Console.WriteLine("3. Dodaj termin u tableu");
                Console.WriteLine("4. Proveri dali termina postoji u tabeli");
                Console.WriteLine("5. Brisi termin sa datim id-om");
                Console.WriteLine("6. Prikazi sve termine");
                Console.WriteLine("7. Update na zadati id");
                Console.WriteLine("8. FindAllById");
                Console.WriteLine("9. Nadji i ispisi jedan termin");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        Console.WriteLine("\nBroj termina u tabeli : " + appointmentService.Count());
                        break;
                    case "2":
                        Console.WriteLine("\nBroj izbrisanih termina: " + appointmentService.DeleteAll());
                        break;
                    case "3":
                        Console.Write("i = ");
                        n = Int32.Parse(Console.ReadLine());
                        List<DBCustomer> customers = (List<DBCustomer>)customerService.FindAll();

                        if (!customers.Any())
                        {
                            Console.WriteLine("Za formiranje Appointment-a potreban je makar jedan Customer");
                        }
                        else
                        {

                            for (int i = 0; i < n; i++)
                            {
                                datum = DateTime.Now;
                                DBAppointment u = new DBAppointment(customers.ElementAt(i % customers.Count()).id, datum, 15.5);
                                if (appointmentService.Save(u) == 1)
                                    Console.WriteLine("dodavanje uspesno");
                            }
                        }
                        break;
                    case "4":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());

                        if (appointmentService.ExistsById(n))
                            Console.WriteLine("Termin postoji");
                        else
                            Console.WriteLine("Termin ne postoji");
                        break;
                    case "5":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());

                        if (appointmentService.DeleteById(n) == 1)
                            Console.WriteLine("Brisanje uspesno");
                        else
                            Console.WriteLine("Brisanje neuspesno");
                        break;
                    case "6":
                        Console.WriteLine();
                        //appointmentService.FindAll();
                        Console.WriteLine(DBAppointment.GetHeader());
                        foreach (DBAppointment termina in appointmentService.FindAll())
                        {
                            Console.WriteLine(termina);
                        }
                        break;
                    case "7":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());
                        datum = DateTime.Now;

                        DBAppointment updateModel = appointmentService.FindById(n);
                        if(updateModel == null)
                        {
                            Console.WriteLine("Nema termina sa datim id-jem da bude update-ovan");
                            break;
                        }
                        updateModel.dateTime = datum;
                        updateModel.price += 1.1;
                        if (appointmentService.Save(updateModel) == 1)
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
                        //appointmentService.FindAllById(idList);
                        Console.WriteLine(DBAppointment.GetHeader());
                        foreach (DBAppointment termina in appointmentService.FindAllById(idList))
                        {
                            Console.WriteLine(termina);
                        }

                        break;
                    case "9":
                        Console.Write("id = ");
                        n = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(DBAppointment.GetHeader());
                        Console.WriteLine(appointmentService.FindById(n));
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
