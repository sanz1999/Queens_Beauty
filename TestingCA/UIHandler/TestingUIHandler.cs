using Common.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model.FrontendModel;
using Common.Methods.CustomerMethodes;

namespace TestingCA.UIHandler
{
    public class TestingUIHandler
    {

        private static readonly AppointmentUIHandler appointmentUI = new AppointmentUIHandler();
        private static readonly CustomerUIHandler customerUI = new CustomerUIHandler();
        private static readonly ServiceUIHandler serviceUI = new ServiceUIHandler();
        private static readonly SIAUIHandler siaUI = new SIAUIHandler();
        private static readonly WorkerUIHandler workerUI = new WorkerUIHandler();


        //sale testira za bazu nesto
        public static BindingList<CustomerFront> Customers { get; private set; }
        private CustomerCRUD commonCustomer = new CustomerCRUD();
        //

        private static readonly ServiceUIHandler usluga = new ServiceUIHandler();
        private static readonly Recognition funkcije = new Recognition();

        public void HandleMainMenu()
        {
            string answer;
            do
            {
                Console.Clear();

                Console.WriteLine("\nZa izlazak uneti x\nOdabir tabele za testiranje:");
                Console.WriteLine("1. Appointment Testing");
                Console.WriteLine("2. Customer Testing");
                Console.WriteLine("3. Service Testing");
                Console.WriteLine("4. SIA (services in a appointment) Testing");
                Console.WriteLine("5. Worker Testing");
                Console.WriteLine("6. Test filter");
                Console.WriteLine("7. Test LoadFromBase");


                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        appointmentUI.MenuHandler();
                        break;
                    case "2":
                        customerUI.MenuHandler();
                        break;
                    case "3":
                        serviceUI.MenuHandler();
                        break;
                    case "4":
                        siaUI.MenuHandler();
                        break;
                    case "5":
                        workerUI.MenuHandler();
                        break;
                    case "6":
                        TestIt();
                        break;
                    case "7":
                        TestDBLoadCustomer();
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
        public void TestDBLoadCustomer() {
            Customers = commonCustomer.LoadFromDataBase();
            Console.WriteLine("Broj customera je = " + Customers.Count());
            string answer = Console.ReadLine();
        }

    }
}
